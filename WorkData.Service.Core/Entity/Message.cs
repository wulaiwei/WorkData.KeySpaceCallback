// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service.Application
// 文件名：Message.cs
// 创建标识：吴来伟 2018-03-20 13:53
// 创建描述：
//  
// 修改标识：吴来伟2018-03-20 13:58
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;

#endregion

namespace WorkData.Service.Core.Entity
{
    /// <summary>
    ///     消息实体
    /// </summary>
    public class Message
    {
        /// <summary>
        ///     key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 服务
        /// </summary>
        public Type DomainService { get; set; }

        /// <summary>
        /// 服务请求体
        /// </summary>
        public string DomainServiceRequest { get; set; }

        /// <summary>
        /// 是否执行标准成功回调
        /// </summary>
        public bool IsSuccessStandardCallBack { get; set; }

        /// <summary>
        /// 是否执行标准失败回调
        /// </summary>
        public bool IsFailStandardCallBack { get; set; }
    }
}