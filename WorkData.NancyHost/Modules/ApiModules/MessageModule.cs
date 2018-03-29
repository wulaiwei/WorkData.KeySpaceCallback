// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.NancyHost
// 文件名：MessageModule.cs
// 创建标识：吴来伟 2018-03-27 15:05
// 创建描述：
//  
// 修改标识：吴来伟2018-03-28 11:45
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using Nancy.Security;
using WorkData.NancyHost.Infrastructure.NancyModuleExtends;
using WorkData.NancyHost.ResponseHandler;
using WorkData.Util.Common.ExceptionExtensions;

#endregion

namespace WorkData.NancyHost.Modules.ApiModules
{
    /// <summary>
    ///     MessageModule
    /// </summary>
    public class MessageModule : ApiNancyModule
    {
        public MessageModule()
        {
            Post["/message/add"] = x =>
            {
                var user= this.Context.CurrentUser;
                //限制认证
                //this.RequiresAuthentication();
                return Response.AsErrorJson("123132");
            };

            Get["/message/all"] = x =>
                throw new UserFriendlyException("我是友好异常！");

            Get["/message/get"] = x =>
                throw new Exception("我是异常！");
        }
    }
}