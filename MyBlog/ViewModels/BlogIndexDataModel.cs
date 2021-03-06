using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class BlogIndexDataModel
    {
        public List<BlogIndexModel> IndexModels { get; set; }

        public List<BlogRatingModel> Ratings { get; set; }
        public BlogSidebarDataModel SidebarData { get; set; } = new BlogSidebarDataModel();
    }
}
