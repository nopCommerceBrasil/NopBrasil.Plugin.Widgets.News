using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using NopBrasil.Plugin.Widgets.News.Service;

namespace NopBrasil.Plugin.Widgets.News.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig nopConfig)
        {
            builder.RegisterType<WidgetNewsService>().As<IWidgetNewsService>().InstancePerDependency();
        }

        public int Order => 2;
    }
}
