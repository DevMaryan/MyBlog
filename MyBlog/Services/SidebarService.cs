using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
using MyBlog.Mappings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Common.Options;
using Microsoft.Extensions.Options;

namespace MyBlog.Services
{
    public class SidebarService : ISidebarService
    {
        private readonly IBlogService _service;
        private readonly SidebarConfig _sidebarConfig;

        public SidebarService(IBlogService service, IOptions<SidebarConfig> sidebarConfig)
        {
            _service = service;
            _sidebarConfig = sidebarConfig.Value;
        }

        public BlogSidebarDataModel GetSidebarData()
        {
            var sidebarDataModel = new BlogSidebarDataModel();

            var mostRecentArticleCount = _sidebarConfig.MostRecentArticlesCount;
            var topArticlesCount = _sidebarConfig.TopArticlesCount;


            var mostRecentArticles = _service.GetMostRecentArticles(mostRecentArticleCount);
            var topArticles = _service.GetTopArticles(topArticlesCount);



            sidebarDataModel.MostRecentArticles = mostRecentArticles.Select(x => x.ToBlogSideBarModel()).ToList();
            sidebarDataModel.TopArticles = topArticles.Select(x => x.ToBlogSideBarModel()).ToList();

            return sidebarDataModel;
        }
    }
}
