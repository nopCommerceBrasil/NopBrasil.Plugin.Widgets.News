using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.News;
using Nop.Services.News;
using Nop.Services.Seo;
using NopBrasil.Plugin.Widgets.News.Models;

namespace NopBrasil.Plugin.Widgets.News.Service
{
    public class WidgetNewsService : IWidgetNewsService
    {
        private readonly INewsService _NewsService;
        private readonly NewsSettings _NewsSettings;
        private readonly ICacheManager _cacheManager;

        public WidgetNewsService(INewsService NewsService, NewsSettings NewsSettings, IStaticCacheManager cacheManager)
        {
            this._NewsService = NewsService;
            this._NewsSettings = NewsSettings;
            this._cacheManager = cacheManager;
        }

        private IPagedList<NewsItem> GetAllNewsPosts()
        {
            string cacheKey = $"nopBrasil:NewsPosts:qtd:{_NewsSettings.QtdNewsPosts}";
            return _cacheManager.Get<IPagedList<NewsItem>>(cacheKey, () => _NewsService.GetAllNews(pageIndex: 0, pageSize: _NewsSettings.QtdNewsPosts));
        }

        public PublicInfoModel GetModel()
        {
            PublicInfoModel model = new PublicInfoModel();
            foreach (var newsItem in GetAllNewsPosts())
            {
                model.NewsItems.Add(new NewsItemModel()
                {
                    CreatedOn = newsItem.CreatedOnUtc,
                    Title = newsItem.Title,
                    Short = newsItem.Short,
                    Full = newsItem.Full,
                    SeName = newsItem.GetSeName(newsItem.LanguageId, ensureTwoPublishedLanguages: false),
                    Id = newsItem.Id
                });
            }
            return model;
        }
    }
}
