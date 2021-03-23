﻿using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;
using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using MyBlog.Common.Exceptions;

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
            article.Date = DateTime.Now;
            _blogRepository.CreateArticle(article);
        }

        // Service -> Delete Article -> Repository Delete
        public void DeleteArticle(int id)
        {
            var article = _blogRepository.GetArticleById(id);
            if(article == null)
            {
                throw new NotFoundException($"The article with {id} was not found.");
            }
            else
            {
                _blogRepository.DeleteArticle(article);
            }

        }
        // Service -> Get Artcile by ID -> Repository Get Title
        public List<Blog> GetArticleByTitle(string title)
        {
            if (title == null)
            {
                return _blogRepository.GetAllArticles();
            }
            else
            {
                return _blogRepository.GetByTitle(title);
            }
        }

        // Service -> Update Article -> Repository UpdateArticle
        public void UpdateArticle(Blog article)
        {

            var updatedArticle = _blogRepository.GetArticleById(article.Id);
            if (updatedArticle != null)
            {
                updatedArticle.Title = article.Title;
                updatedArticle.ImageUrl = article.ImageUrl;
                updatedArticle.Content = article.Content;
                updatedArticle.Author = article.Author;
                updatedArticle.DateModified = DateTime.Now;
                _blogRepository.UpdateArticle(updatedArticle);
            }
            else
            {
                throw new NotFoundException($"The movie with id {article.Id} was not found");
            }
        }
    }
}
