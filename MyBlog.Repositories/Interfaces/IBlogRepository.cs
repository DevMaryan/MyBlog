using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;

namespace MyBlog.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetAllArticles();
        Blog GetArticleById(int id);
        void CreateArticle(Blog article);
        void DeleteArticle(Blog article);
        List<Blog> GetByTitle(string title);
    }
}
