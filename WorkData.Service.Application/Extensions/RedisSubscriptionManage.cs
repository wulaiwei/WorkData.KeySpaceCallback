﻿// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service.Application
// 文件名：RedisSubscriptionManage.cs
// 创建标识：吴来伟 2018-03-22 16:35
// 创建描述：
//  
// 修改标识：吴来伟2018-03-23 15:09
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using Newtonsoft.Json;
using WorkData.Dependency;
using WorkData.Service.Application.Dependency;
using WorkData.Service.Core.Entity;
using WorkData.Util.Redis.Interface;

#endregion

namespace WorkData.Service.Application.Extensions
{
    public class RedisSubscriptionManage
    {
        private readonly IIocManager _iocManager;
        private readonly IRedisService _redisService;

        public RedisSubscriptionManage(IIocManager iocManager, IRedisService redisService)
        {
            _iocManager = iocManager;
            _redisService = redisService;
        }

        /// <summary>
        ///     订阅
        /// </summary>
        public void CreateRedisSubscription(Message message)
        {
            using (var redisClient = _redisService.GetClient())
            {
                try
                {
                    //判断重启之前是否redis是否已释放过期数据，如果过期当前时间添加30秒重新触发事件
                    var data = redisClient.Get<string>($"{message.Key}");

                    if (string.IsNullOrEmpty(data))
                    {
                        redisClient.Set(
                            $"{message.Key}", $"{message.Key}", DateTime.Now.AddSeconds(5));
                    }

                    //创建订阅
                    var subscription = redisClient.CreateSubscription();

                    //接收消息处理Action
                    subscription.OnMessage = (channel, msg) =>
                    {
                        var baseImplType = typeof(DomainServiceProxy<>);
                        var genericRepositoryType = baseImplType
                            .MakeGenericType(message.DomainService);
                        var proxy = _iocManager.Resolve(genericRepositoryType) as dynamic;

                        var request = JsonConvert.DeserializeObject
                            (message.DomainServiceRequest, message.DomainService) as dynamic;

                        proxy.Execute(request, message);
                    };

                    //订阅事件处理
                    subscription.OnSubscribe = channel => { };

                    //取消订阅事件处理
                    subscription.OnUnSubscribe = a =>
                    {
                        //subscription.Dispose();
                    };

                    //__keyspace@0__ 为固定格式 0代表DB数据库的位置db0
                    //订阅频道
                    subscription.SubscribeToChannels($"__keyspace@0__:{message.Key}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}