using Autofac;
using SocialMedia.Core.Interfaces.Repositories;
using SocialMedia.Core.Interfaces.Services;
using SocialMedia.Core.Services;
using SocialMedia.Infra.Data.Repositories;

namespace SocialMedia.Infra.IoC
{
    public class ConfigurationIoC
    {
         public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();
            builder.RegisterType<RepositoryPost>().As<IRepositoryPost>();
            builder.RegisterType<ServicePost>().As<IServicePost>();
            //builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();
            //builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
            //builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
            //builder.RegisterType<ServiceUser>().As<IServiceUser>();
            //builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            //builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();
            //builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();
            //builder.RegisterType<MapperCliente>().As<IMapperCliente>();
            //builder.RegisterType<MapperProduto>().As<IMapperProduto>();
            //builder.RegisterType<MapperUser>().As<IMapperUser>();
        }
    }
}