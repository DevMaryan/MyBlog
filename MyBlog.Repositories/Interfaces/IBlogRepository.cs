using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;

namespace MyBlog.Repositories.Interfaces
{
    public interface IBlogRepository : IBaseRepository<Blog>
    {

        List<Blog> GetByTitle(string title);
        Blog GetByArticleId(int entityId);

        List<Blog> GetMostRecentArticles(int count);
        List<Blog> GetTopArticles(int count);
    }
}
