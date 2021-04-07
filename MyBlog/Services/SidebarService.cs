using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
using MyBlog.Mappings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    public class SidebarService : ISidebarService
    {
        private readonly IBlogService _service;

        public SidebarService(IBlogService service)
        {
            _service = service;
        }

        public BlogSidebarDataModel GetSidebarData()
        {
            var sidebarDataModel = new BlogSidebarDataModel();

            var mostRecentArticles = _service.GetMostRecentArticles(3);
            var topArticles = _service.GetTopArticles(3);



            sidebarDataModel.MostRecentArticles = mostRecentArticles.Select(x => x.ToBlogSideBarModel()).ToList();
            sidebarDataModel.TopArticles = topArticles.Select(x => x.ToBlogSideBarModel()).ToList();

            return sidebarDataModel;
        }
    }
}
