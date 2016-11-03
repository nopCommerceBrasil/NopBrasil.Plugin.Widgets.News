using System.Web.Mvc;
using NopBrasil.Plugin.Widgets.News.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;
using Nop.Web.Controllers;
using NopBrasil.Plugin.Widgets.News.Service;

namespace NopBrasil.Plugin.Widgets.News.Controllers
{
    public class WidgetsNewsController : BasePublicController
    {
        private readonly ISettingService _settingService;
        private readonly NewsSettings _NewsSettings;
        private readonly IWidgetNewsService _widgetNewsService;

        public WidgetsNewsController(ISettingService settingService,
            NewsSettings NewsSettings, IWidgetNewsService widgetNewsService)
        {
            this._settingService = settingService;
            this._NewsSettings = NewsSettings;
            this._widgetNewsService = widgetNewsService;
        }

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            var model = new ConfigurationModel()
            {
                WidgetZone = _NewsSettings.WidgetZone,
                QtdNewsPosts = _NewsSettings.QtdNewsPosts
            };
            return View("~/Plugins/Widgets.News/Views/WidgetsNews/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
            {
                return Configure();
            }
            _NewsSettings.QtdNewsPosts = model.QtdNewsPosts;
            _NewsSettings.WidgetZone = model.WidgetZone;
            _settingService.SaveSetting(_NewsSettings);
            return Configure();
        }

        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone, object additionalData = null)
        {
             return View("~/Plugins/Widgets.News/Views/WidgetsNews/PublicInfo.cshtml", _widgetNewsService.GetModel());
        }
    }
}