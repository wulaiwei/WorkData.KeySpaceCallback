// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.NancyHost
// 文件名：OAuthModule.cs
// 创建标识：吴来伟 2018-03-29 9:22
// 创建描述：
//  
// 修改标识：吴来伟2018-03-29 9:22
// 修改描述：
//  ------------------------------------------------------------------------------

using Nancy.ModelBinding;
using WorkData.NancyHost.Infrastructure.NancyModuleExtends;
using WorkData.NancyHost.Models.Tokens;
using WorkData.NancyHost.ResponseHandler;

namespace WorkData.NancyHost.Modules.OAuthModules
{
    public class AuthModule: OAuthModule
    {
        public AuthModule()
        {
            Post["/accessToken"] = x =>
            {
                var userOAuthRequest = this.Bind<UserOAuthRequest>();
                if (userOAuthRequest==null)
                {
                    return Response.AsErrorJson("非法访问！");
                }
                if (userOAuthRequest.Password==string.Empty)
                {
                    
                }
                return Response.AsSuccessJson("");
            };
        }
    }
}