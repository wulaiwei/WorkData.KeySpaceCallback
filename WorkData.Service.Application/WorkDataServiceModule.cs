using Autofac;
using WorkData.Extensions.Modules;
using WorkData.Extensions.Types;
using WorkData.Service.Application.Dependency;
using WorkData.Service.Application.Extensions;
using WorkData.Service.Application.Impls;
using WorkData.Service.Core.Entity;
using WorkData.Service.Core.Settings;
using WorkData.Util.Redis;

namespace WorkData.Service.Application
{
    /// <summary>
    /// WorkDataServiceModule
    /// </summary>s
    [DependsOn(typeof(WorkDataRedisModule))]
    public class WorkDataServiceModule : WorkDataBaseModule
    {
        private readonly ILoadType _loadType;
        public WorkDataServiceModule()
        {
            _loadType = NullLoadType.Instance;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //自动用Services里的类来注册相应实例，无须一个个注册
            builder.RegisterType<InsertDomainService>()
                .As<IDomainService<Insert>>();
            builder.RegisterType<CallBackService>();
            builder.RegisterType(typeof(DomainServiceProxy<>));
            builder.RegisterType<RedisSubscriptionManage>();

            RegisterMatchDbContexts();
        }


        /// <summary>
        ///     RegisterMatchDbContexts
        /// </summary>
        private void RegisterMatchDbContexts()
        {
            if (IocManager == null)
                return;
            var types = _loadType.GetAll(x => x.IsPublic && x.IsClass && !x.IsAbstract
                                              && typeof(ICallBack).IsAssignableFrom(x));
            var builder = new ContainerBuilder();
            foreach (var type in types)
            {
                var baseImplType = typeof(DomainServiceProxy<>);
                var implType = baseImplType.MakeGenericType(type);
                builder.RegisterType(implType);
            }
            IocManager.UpdateContainer(builder);
        }
    }
}