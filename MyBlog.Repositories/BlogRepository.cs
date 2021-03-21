using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System.Linq;

namespace MyBlog.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        public ArticlesDbContext _context { get; set; }

        public BlogRepository (ArticlesDbContext context)
        {
            _context = context;
        }
        // Create Article
        public void CreateArticle(Blog article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        // Get all Articles
        public List<Blog> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        // Get Articles by ID
        public Blog GetArticleById(int id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }
        // DELETE article
        public void DeleteArticle(Blog article)
        {
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }
        // Search - Get by Title
        public List<Blog> GetByTitle(string title)
        {
            return _context.Articles.Where(x => x.Title.Contains(title)).ToList();
        }

        public void UpdateArticle(Blog article)
        {
            _context.Articles.Update(article);
            _context.SaveChanges();
        }
    }
}
