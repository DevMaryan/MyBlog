using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories.Interfaces
{
    public interface IRatingsRepository
    {
        void AddRating(Rating rate);
        double AvgScore();
    }
}
