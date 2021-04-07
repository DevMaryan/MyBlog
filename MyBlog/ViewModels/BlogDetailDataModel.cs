using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class BlogDetailDataModel
    {
        public BlogDetailModel BlogDetail { get; set; }

        public BlogSidebarDataModel blogSidebarData { get; set; } = new BlogSidebarDataModel();
    }
}
