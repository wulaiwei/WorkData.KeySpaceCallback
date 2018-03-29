// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service.Application
// 文件名：ImmediateSubscription.cs
// 创建标识：吴来伟 2018-03-26 17:42
// 创建描述：
//  
// 修改标识：吴来伟2018-03-26 17:42
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using Newtonsoft.Json;
using WorkData.Dependency;
using WorkData.Service.Core.Entity;
using WorkData.Util.Redis.Interface;

namespace WorkData.Service.Application.Dependency
{
    /// <summary>
    /// ImmediateSubscription
    /// </summary>
    public class ImmediateSubscription: IWorkDataSubscription
    {
        private readonly IIocManager _iocManager;
        private readonly IRedisService _redisService;

        public ImmediateSubscription(IIocManager iocManager, IRedisService redisService)
        {
            _iocManager = iocManager;
            _redisService = redisService;
        }

        /// <summary>
        ///     订阅
        /// </summary>
        public void CreateRedisSubscription(Message message)
        {
            var baseGenericType = typeof(DomainServiceProxy<>);
            var genericProxyType = baseGenericType
                .MakeGenericType(message.DomainService);
            var proxy = _iocManager.Resolve(genericProxyType) as dynamic;

            var request = JsonConvert.DeserializeObject
                (message.DomainServiceRequest, message.DomainService) as dynamic;

            proxy.Execute(request, message);
        }
    }
}