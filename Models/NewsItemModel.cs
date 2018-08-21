using Nop.Web.Framework.Mvc.Models;
using System;

namespace NopBrasil.Plugin.Widgets.News.Models
{
    public class NewsItemModel : BaseNopEntityModel
    {
        public string Title { get; set; }

        public string Short { get; set; }

        public string Full { get; set; }

        public string SeName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
