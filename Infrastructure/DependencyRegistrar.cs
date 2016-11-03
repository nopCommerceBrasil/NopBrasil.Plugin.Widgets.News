using Autofac;
using Autofac.Core;
using Nop.Core.Caching;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using NopBrasil.Plugin.Widgets.News.Controllers;
using NopBrasil.Plugin.Widgets.News.Service;

namespace NopBrasil.Plugin.Widgets.News.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig nopConfig)
        {
            //we cache presentation models between requests
            builder.RegisterType<WidgetsNewsController>().AsSelf();
            builder.RegisterType<WidgetNewsService>().As<IWidgetNewsService>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static")).InstancePerDependency();
        }

        public int Order
        {
            get { return 2; }
        }
    }
}
