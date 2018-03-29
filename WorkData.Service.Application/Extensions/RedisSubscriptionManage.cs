// ------------------------------------------------------------------------------
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
        public IWorkDataSubscription CreateRedisSubscription(Message message)
        {
            switch (message.MessageType)
            {
                case MessageType.定时回调:
                    return new TimingWorkDataSubscription(_iocManager, _redisService);
                case MessageType.直接执行:
                    return new ImmediateSubscription(_iocManager, _redisService);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}