using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Repositories 
{
    public class RatingsRepository : IRatingsRepository
    {
        private readonly ArticlesDbContext _context;

        public RatingsRepository(ArticlesDbContext context)
        {
            _context = context;
        }

        public void AddRating(Rating rate)
        {
            _context.Ratings.Add(rate);
            _context.SaveChanges();
        }

        public double AvgScore()
        {

            return _context.Ratings.Average(x => x.Score);
        }
    }
}
