using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Mvc.Models;

namespace NopBrasil.Plugin.Widgets.News.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.News.Fields.WidgetZone")]
        public string WidgetZone { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.News.Fields.QtdNewsPosts")]
        public int QtdNewsPosts { get; set; }
    }
}