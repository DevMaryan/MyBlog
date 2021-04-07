using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public Blog GetByArticleId(int entityId)
        {
            var article = _context.Articles
                 .Include(x => x.Comments)
                     .ThenInclude(x => x.User)
                .Include(x => x.Ratings)
                    .ThenInclude(x => x.User)
                 .FirstOrDefault(x => x.Id == entityId);
            return article;
        }

        public double AvgScore()
        {

            return _context.Ratings.Average(x => x.Score);
        }
    }
}
