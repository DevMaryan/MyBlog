using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;

namespace MyBlog.Services.Interfaces
{
    public interface IBlogService
    {
        List<Blog> GetAllArticles();
        List<Blog> GetArticleByTitle(string title);

        Blog GetArticleById(int id);

        Blog GetArticleDetails(int id);
        void CreateArticle(Blog article);
        void UpdateArticle(Blog article);
        void DeleteArticle(int id);
        bool Like(int id);
        List<Blog> GetMostRecentArticles(int count);
        List<Blog> GetTopArticles(int count);
    }
}
