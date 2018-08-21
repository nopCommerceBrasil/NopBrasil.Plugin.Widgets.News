using NopBrasil.Plugin.Widgets.News.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Localization;

namespace NopBrasil.Plugin.Widgets.News.Controllers
{
    [Area(AreaNames.Admin)]
    public class WidgetsNewsController : BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly NewsSettings _NewsSettings;
        private readonly ILocalizationService _localizationService;

        public WidgetsNewsController(ISettingService settingService,
            NewsSettings NewsSettings, ILocalizationService localizationService)
        {
            this._settingService = settingService;
            this._NewsSettings = NewsSettings;
            this._localizationService = localizationService;
        }

        public ActionResult Configure()
        {
            var model = new ConfigurationModel()
            {
                WidgetZone = _NewsSettings.WidgetZone,
                QtdNewsPosts = _NewsSettings.QtdNewsPosts
            };
            return View("~/Plugins/Widgets.News/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();

            _NewsSettings.QtdNewsPosts = model.QtdNewsPosts;
            _NewsSettings.WidgetZone = model.WidgetZone;
            _settingService.SaveSetting(_NewsSettings);
            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}