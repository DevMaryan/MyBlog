using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class BlogDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public DateTime Date { get; set; }
        public DateTime? DateModified { get; set; }
        public bool Like { get; set; }
        public List<BlogCommentModel> Comments { get; set; }

        public List<BlogRatingModel> Ratings { get; set; }

        public int Views { get; set; }
    }
}
