using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;
using MyBlog.Repositories;
namespace MyBlog.Services
{
    public class BlogService
    {
        public BlogRepository _blogRepository { get; set; }

        public BlogService()
        {
            _blogRepository = new BlogRepository();
        }

        public List<Blog> GetAllArticles()
        {
            return _blogRepository.GetAllArticles();
        }

        public Blog GetArticleById(int id)
        {
            return _blogRepository.GetArticleById(id);
        }
    }
}
