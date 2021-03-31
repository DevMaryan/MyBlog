using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System.Linq;

namespace MyBlog.Repositories
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {

        public BlogRepository (ArticlesDbContext context) : base(context)
        {

        }

        // Search - Get by Title
        public List<Blog> GetByTitle(string title)
        {
            return _context.Articles.Where(x => x.Title.Contains(title)).ToList();
        }

    }
}
