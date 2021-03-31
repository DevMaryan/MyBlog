﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }

        public int ArticleId { get; set; }
        public Blog Article { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
