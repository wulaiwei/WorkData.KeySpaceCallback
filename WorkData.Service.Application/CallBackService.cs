// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service.Application
// 文件名：CallBackService.cs
// 创建标识：吴来伟 2018-03-21 14:05
// 创建描述：
//  
// 修改标识：吴来伟2018-03-21 14:05
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WorkData.Dependency;
using WorkData.Service.Application.Dependency;
using WorkData.Service.Application.Extensions;
using WorkData.Service.Core.Entity;
using WorkData.Util.Common.Logs;
using WorkData.Util.Redis.Entity;
using WorkData.Util.Redis.Impl;
using WorkData.Util.Redis.RealTime;

#endregion

namespace WorkData.Service.Application
{
    public class CallBackService
    {
        /// <summary>
        ///     CancellationTokenSource
        /// </summary>
        private readonly CancellationTokenSource _cancelTokenSource =
            new CancellationTokenSource();
        /// <summary>
        ///     RedisService
        /// </summary>
        private readonly BaseRedisServiceManager _baseRedisServiceManager;
        private readonly RedisSubscriptionManage _redisSubscriptionManage;
        public CallBackService(BaseRedisServiceManager baseRedisServiceManager, RedisSubscriptionManage redisSubscriptionManage)
        {
            _baseRedisServiceManager = baseRedisServiceManager;
            _redisSubscriptionManage = redisSubscriptionManage;
        }
        /// <summary>
        ///     Start
        /// </summary>
        public bool Start()
        {
            for (var i = 0; i < 10000; i++)
            {
                var message = new RedisQueue<Message>
                {
                    Key = "RedisKepSpaceQueue",
                    Entity = new Message
                    {
                        Key = Guid.NewGuid().ToString(),
                        DomainService = typeof(Insert),
                        DomainServiceRequest = JsonConvert.SerializeObject(new Insert
                        {
                            Id = 1,
                            Title = DateTime.Now.ToLongDateString()
                        })
                    }

                };

                _baseRedisServiceManager.AddQueue(message);
            }


            //新进程
            Task.Factory.StartNew(DelayStart, _cancelTokenSource.Token);

            return true;
        }

        /// <summary>
        ///     Stop
        /// </summary>
        public bool Stop()
        {
            //关闭新开线程
            _cancelTokenSource.Cancel();
            _cancelTokenSource.Dispose();

            return true;
        }

        #region 开启新线程，避免服务启动失败

        /// <summary>
        ///     延迟启动
        /// </summary>
        private void DelayStart()
        {
            //新进程
            while (!_cancelTokenSource.IsCancellationRequested) // Worker thread loop
            {
                try
                {
                    var item = _baseRedisServiceManager.BlockingPopQueue<Message>("RedisKepSpaceQueue", null);
                    // 注意：订阅信道的时候 会开启阻塞模式，所以，需要将监听放到单独的线程里
                    Task.Factory.StartNew(() =>
                    {
                        _redisSubscriptionManage.CreateRedisSubscription(item);
                    });
                }
                catch (Exception ex)
                {
                    //异常处理
                    LoggerHelper.SystemLog.Error(ex.Message); 
                }
            }
        }

        #endregion
    }
}