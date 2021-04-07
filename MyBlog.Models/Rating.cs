using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
