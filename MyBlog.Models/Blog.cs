using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(maximumLength: 120, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public DateTime? DateModified { get; set; }

        public List<Comment> Comments { get; set; }

        public bool Likes { get; set; }

    }
}
