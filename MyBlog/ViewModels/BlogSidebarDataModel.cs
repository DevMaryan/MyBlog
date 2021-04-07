using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class BlogSidebarDataModel
    {
        public List<BlogSidebarModel> MostRecentArticles { get; set; } = new List<BlogSidebarModel>();

        public List<BlogSidebarModel> TopArticles { get; set; } = new List<BlogSidebarModel>();
    }
}
