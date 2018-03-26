// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service.Application
// 文件名：DomainServiceProxy.cs
// 创建标识：吴来伟 2018-03-22 15:42
// 创建描述：
//  
// 修改标识：吴来伟2018-03-22 15:42
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using WorkData.Service.Core.Entity;
using WorkData.Service.Core.Settings;
using WorkData.Util.Common.Logs;

namespace WorkData.Service.Application.Dependency
{
    /// <summary>
    /// DomainServiceProxy
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DomainServiceProxy<T> where T : class
    {

        private readonly IDomainService<T> _callBack;

        public DomainServiceProxy(IDomainService<T> callBack)
        {
            _callBack = callBack;
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"></param>
        public void Execute(T entity, Message message)
        {
            try
            {
                var handlingResult = _callBack.Execute(entity);
                if (message.IsSuccessStandardCallBack)
                    SuccessStandardCallBack(message, handlingResult);
                if (message.IsFailStandardCallBack)
                    FailStandardCallBack(message, handlingResult);
            }
            catch (Exception ex)
            {
                LoggerHelper.SystemLog.Error(ex.Message); //(message.Id);
            }
        }


        /// <summary>
        /// 标准成功回调函数
        /// </summary>
        /// <param name="message"></param>
        /// <param name="handlingResult"></param>
        public void SuccessStandardCallBack(Message message, HandlingResult handlingResult)
        {

        }


        /// <summary>
        /// 标准失败回调函数
        /// </summary>
        /// <param name="message"></param>
        /// <param name="handlingResult"></param>
        public void FailStandardCallBack(Message message, HandlingResult handlingResult)
        {

        }
    }
}