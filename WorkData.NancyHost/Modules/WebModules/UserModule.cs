// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.NancyHost
// 文件名：UserModule.cs
// 创建标识：吴来伟 2018-03-28 17:37
// 创建描述：
//  
// 修改标识：吴来伟2018-03-28 17:38
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using Nancy.ModelBinding;
using WorkData.NancyHost.Infrastructure.NancyModuleExtends;
using WorkData.NancyHost.Models;
using WorkData.NancyHost.Models.Tokens;
using WorkData.NancyHost.ResponseHandler;
using WorkData.Service.Domain.UserBases;
using WorkData.Service.Domain.UserBases.Services;

namespace WorkData.NancyHost.Modules.WebModules
{
    public class UserModule : WebNancyModule
    {
        public UserModule(IUserMapper userMapper,IUserBaseService userBaseService)
        {
            //获取新增用户
            Post["/user/add"] = x =>
            {
                var entity = this.Bind<UserBase>();
                entity.Id = Guid.NewGuid().ToString();
                entity.CreateTime = DateTime.Now;

                var data= userBaseService.AddUserBase(entity);
                return Response.AsSuccessJson(data);
            };
        }
    }
}