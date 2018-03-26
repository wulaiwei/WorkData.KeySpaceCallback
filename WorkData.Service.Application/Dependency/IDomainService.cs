// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service.Application
// 文件名：IDomainService.cs
// 创建标识：吴来伟 2018-03-20 11:02
// 创建描述：
//  
// 修改标识：吴来伟2018-03-20 12:29
// 修改描述：
//  ------------------------------------------------------------------------------


using WorkData.Service.Core.Settings;

namespace WorkData.Service.Application.Dependency
{
    /// <summary>
    /// 服务
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDomainService<in T> where T:class
    {
        /// <summary>
        /// 回调执行任务
        /// </summary>
        /// <param name="message"></param>
        HandlingResult Execute(T message);
    }
}