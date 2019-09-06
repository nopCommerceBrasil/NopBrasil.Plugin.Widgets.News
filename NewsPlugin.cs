using System.Collections.Generic;
using Nop.Core;
using Nop.Services.Plugins;
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
        private readonly ILocalizationService _localizationService;

        public NewsPlugin(ISettingService settingService, NewsSettings NewsSettings, IWebHelper webHelper, ILocalizationService localizationService)
        {
            this._settingService = settingService;
            this._NewsSettings = NewsSettings;
            this._webHelper = webHelper;
            this._localizationService = localizationService;
        }

        public IList<string> GetWidgetZones() => new List<string> { _NewsSettings.WidgetZone };

        public override string GetConfigurationPageUrl() => _webHelper.GetStoreLocation() + "Admin/WidgetsNews/Configure";

        public override void Install()
        {
            var settings = new NewsSettings
            {
                QtdNewsPosts = 3,
                WidgetZone = "home_page_before_news"
            };
            _settingService.SaveSetting(settings);

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.News.Fields.WidgetZone", "WidgetZone name");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.News.Fields.WidgetZone.Hint", "Enter the WidgetZone name that will display the HTML code.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.News.Fields.QtdNewsPosts", "Number of News items");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.News.Fields.QtdNewsPosts.Hint", "Enter the number of News items that will be displayed in view.");

            base.Install();
        }

        public override void Uninstall()
        {
            _settingService.DeleteSetting<NewsSettings>();

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.WidgetZone");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.WidgetZone.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.QtdNewsPosts");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.News.Fields.QtdNewsPosts.Hint");

            base.Uninstall();
        }

        public string GetWidgetViewComponentName(string widgetZone) => "WidgetsNews";

        public bool HideInWidgetList => false;
    }
}