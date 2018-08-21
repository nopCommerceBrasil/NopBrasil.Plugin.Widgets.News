using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using NopBrasil.Plugin.Widgets.News.Service;

namespace NopBrasil.Plugin.Widgets.ContactData.Component
{
    [ViewComponent(Name = "WidgetsNews")]
    public class WidgetsNewsViewComponent : NopViewComponent
    {
        private readonly IWidgetNewsService _widgetNewsService;

        public WidgetsNewsViewComponent(IWidgetNewsService widgetNewsService)
        {
            this._widgetNewsService = widgetNewsService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData) => View("~/Plugins/Widgets.News/Views/PublicInfo.cshtml", _widgetNewsService.GetModel());
    }
}
