using System.Collections.Generic;
using System.Web.Routing;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;

namespace NopBrasil.Plugin.Widgets.News
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class NewsPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        private readonly NewsSettings _NewsSettings;

        public NewsPlugin(IPictureService pictureService,
            ISettingService settingService, NewsSettings NewsSettings)
        {
            this._settingService = settingService;
            this._NewsSettings = NewsSettings;
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { _NewsSettings.WidgetZone };
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "WidgetsNews";
            routeValues = new RouteValueDictionary { { "Namespaces", "NopBrasil.Plugin.Widgets.News.Controllers" }, { "area", null } };
        }

        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "WidgetsNews";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "NopBrasil.Plugin.Widgets.News.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }

        public override void Install()
        {
            var settings = new NewsSettings
            {
                QtdNewsPosts = 3,
                WidgetZone = "home_page_before_news"
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.News.Fields.WidgetZone", "WidgetZone name");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.News.Fields.WidgetZone.Hint", "Enter the WidgetZone name that will display the HTML code.");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.News.Fields.QtdNewsPosts", "Number of News items");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.News.Fields.QtdNewsPosts.Hint", "Enter the number of News items that will be displayed in view.");

            base.Install();
        }

        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<NewsSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.WidgetZone");
            this.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.WidgetZone.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.QtdNewsPosts");
            this.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.QtdNewsPosts.Hint");

            base.Uninstall();
        }
    }
}
