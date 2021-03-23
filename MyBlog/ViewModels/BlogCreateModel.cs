using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.ViewModels
{
    public class BlogCreateModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
