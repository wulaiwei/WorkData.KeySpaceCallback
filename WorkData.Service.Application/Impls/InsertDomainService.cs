// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service.Application
// 文件名：InsertDomainService.cs
// 创建标识：吴来伟 2018-03-21 13:51
// 创建描述：
//  
// 修改标识：吴来伟2018-03-21 13:51
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Service.Application.Dependency;
using WorkData.Service.Core.Entity;
using WorkData.Service.Core.Settings;
using WorkData.Util.Common.Logs;

namespace WorkData.Service.Application.Impls
{
    /// <summary>
    /// InsertDomainService
    /// </summary>
    public class InsertDomainService: BaseDomainService<Insert>
    {
        public override HandlingResult Execute(Insert message)
        {
            LoggerHelper.SystemLog.Error(message.Id); //(message.Id);
            return null;
        }
    }
}