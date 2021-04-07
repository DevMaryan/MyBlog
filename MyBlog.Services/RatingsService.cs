using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services
{
    public class RatingsService : IRatingsService
    {
        private readonly IRatingsRepository _ratingsRepository;

        public RatingsService(IRatingsRepository ratingsRepository)
        {
            _ratingsRepository = ratingsRepository;
        }

        public void Add(int scoreId, int blogId, int userId)
        {
            var newRatings = new Rating()
            {
                Score = scoreId,
                BlogId = blogId,
                UserId = userId,

            };
            _ratingsRepository.AddRating(newRatings);

        }

        public double AvgScore()
        {
            return _ratingsRepository.AvgScore();
        }
    }
}
