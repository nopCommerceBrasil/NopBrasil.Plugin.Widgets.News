using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace NopBrasil.Plugin.Widgets.News
{
    public class NewsPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        private readonly NewsSettings _NewsSettings;
        private readonly IWebHelper _webHelper;

        public NewsPlugin(ISettingService settingService, NewsSettings NewsSettings, IWebHelper webHelper)
        {
            this._settingService = settingService;
            this._NewsSettings = NewsSettings;
            this._webHelper = webHelper;
        }

        public IList<string> GetWidgetZones() => new List<string> { _NewsSettings.WidgetZone };

        public override string GetConfigurationPageUrl() => _webHelper.GetStoreLocation() + "Admin/WidgetsNews/Configure";

        public void GetPublicViewComponent(string widgetZone, out string viewComponentName) => viewComponentName = "WidgetsNews";

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
            _settingService.DeleteSetting<NewsSettings>();

            this.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.WidgetZone");
            this.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.WidgetZone.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.QtdNewsPosts");
            this.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.QtdNewsPosts.Hint");

            base.Uninstall();
        }
    }
}