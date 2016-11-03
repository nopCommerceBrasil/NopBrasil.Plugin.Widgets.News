using Nop.Core.Configuration;

namespace NopBrasil.Plugin.Widgets.News
{
    public class NewsSettings : ISettings
    {
        public string WidgetZone { get; set; }
        public int QtdNewsPosts { get; set; }
    }
}