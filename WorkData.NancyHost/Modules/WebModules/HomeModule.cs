// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.NancyHost
// 文件名：HomeModule.cs
// 创建标识：吴来伟 2018-03-27 14:35
// 创建描述：
//  
// 修改标识：吴来伟2018-03-27 14:35
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using Nancy.Security;
using WorkData.NancyHost.Infrastructure.NancyModuleExtends;
using WorkData.Service.Core.Bussiness;
using WorkData.Service.Core.Entity;
using Newtonsoft.Json;
using Dapper;
using WorkData.Service.Domain;
using WorkData.Service.Domain.UserBases;

namespace WorkData.NancyHost.Modules.WebModules
{
    public class HomeModule : WebNancyModule
    {
        //注意：这里是构造函数
        public HomeModule()
        {

            //默认页
            Get["/"] = p =>
            {
                return View["/Home/Index"];
            };
        }
    }
}