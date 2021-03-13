using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;

namespace MyBlog.Services.Interfaces
{
    public interface IBlogService
    {
        List<Blog> GetAllArticles();

        Blog GetArticleById(int id);

        void CreateArticle(Blog article);
    }
}
