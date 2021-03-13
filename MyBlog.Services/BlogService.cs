using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;
using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
namespace MyBlog.Services
{
    public class BlogService :  IBlogService
    {
        public IBlogRepository _blogRepository { get; set; }

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        // Service -> GetAllArticles -> Repository
        public List<Blog> GetAllArticles()
        {
            return _blogRepository.GetAllArticles();
        }

        // Service -> Get Article id -> Repository by id
        public Blog GetArticleById(int id)
        {
            return _blogRepository.GetArticleById(id);
        }

        // Service -> CreateArticle -> Repository Create Article 
        public void CreateArticle(Blog article)
        {
            _blogRepository.CreateArticle(article);
        }
    }
}
