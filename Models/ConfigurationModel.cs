using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace NopBrasil.Plugin.Widgets.News.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.News.Fields.WidgetZone")]
        [AllowHtml]
        public string WidgetZone { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.News.Fields.QtdNewsPosts")]
        [AllowHtml]
        public int QtdNewsPosts { get; set; }
    }
}