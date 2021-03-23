using System;
using System.ComponentModel.DataAnnotations;


namespace MyBlog.ViewModels
{
    public class BlogUpdateModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

    }
}
