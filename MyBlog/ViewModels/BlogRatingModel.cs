using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class BlogRatingModel
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public int BlogId { get; set; }
        public string Username { get; set; }
    }
}
