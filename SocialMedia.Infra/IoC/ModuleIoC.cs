using Autofac;

namespace SocialMedia.Infra.IoC
{
    public class ModuleIoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIoC.Load(builder);
        }
    }
}