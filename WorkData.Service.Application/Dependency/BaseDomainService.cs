// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service.Application
// 文件名：BaseDomainService.cs
// 创建标识：吴来伟 2018-03-21 13:48
// 创建描述：
//  
// 修改标识：吴来伟2018-03-21 13:54
// 修改描述：
//  ------------------------------------------------------------------------------

#region

#endregion

using WorkData.Service.Core.Settings;

namespace WorkData.Service.Application.Dependency
{
    /// <inheritdoc />
    /// <summary>
    ///     基础服务
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseDomainService<T> : IDomainService<T> where T : class
    {
        public abstract HandlingResult Execute(T message);
    }
}