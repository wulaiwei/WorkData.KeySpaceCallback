// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.NancyHost
// 文件名：WorkDataNancyBootstrapper.cs
// 创建标识：吴来伟 2018-03-27 15:16
// 创建描述：
//  
// 修改标识：吴来伟2018-03-27 15:16
// 修改描述：
//  ------------------------------------------------------------------------------
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using WorkData.NancyHost.Models.Tokens;
using WorkData.NancyHost.ResponseHandler;
using WorkData.Service.Domain.UserBases.Services;

namespace WorkData.NancyHost.Infrastructure
{
    public class WorkDataNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            //替换默认序列化方式
            container.Register<ISerializer, CustomJsonNetSerializer>();
            container.Register<IUserMapper, UserMapper>();

            #region 业务注入
            container.Register<IUserBaseService, UserBaseService>(); 
            #endregion

            var configuration = new StatelessAuthenticationConfiguration(
                nancyContext =>
            {
                //返回null代码token无效或用户未认证
                var token = nancyContext.Request.Headers.Authorization;
                var userValidator = container.Resolve<IUserMapper>();
                return !string.IsNullOrEmpty(token) ?
                    userValidator.GetUserFromAccessToken(token) : null;
            }
                );

            StatelessAuthentication.Enable(pipelines, configuration);

            base.ApplicationStartup(container, pipelines);
        }
    }
}