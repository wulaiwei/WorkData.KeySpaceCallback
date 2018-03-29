// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service.Application
// 文件名：UpdateDomainService.cs
// 创建标识：吴来伟 2018-03-26 17:55
// 创建描述：
//  
// 修改标识：吴来伟2018-03-26 17:55
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Service.Application.Dependency;
using WorkData.Service.Core.Bussiness;
using WorkData.Service.Core.Settings;
using WorkData.Util.Common.Logs;

namespace WorkData.Service.Application.Impls
{
    public class UpdateDomainService : BaseDomainService<Update>
    {
        public override HandlingResult Execute(Update message)
        {
            LoggerHelper.SystemLog.Error($"update:{message.Id}"); 
            return null;
        }
    }
}