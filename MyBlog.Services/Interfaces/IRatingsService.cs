using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services.Interfaces
{
    public interface IRatingsService
    {
        void Add(int scoreId, int blogId, int userId);
        double AvgScore();
    }
}
