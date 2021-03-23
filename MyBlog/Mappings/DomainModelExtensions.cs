using MyBlog.Models;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;

namespace MyBlog.Mappings
{
    public static class DomainModelExtensions
    {
        public static BlogAdminModel ToAdminModel(this Blog article)
        {
            return new BlogAdminModel()
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                ImageUrl = article.ImageUrl,
                Author = article.Author,
                Date = article.Date,
                DateModified = article.DateModified,
            };
        }

        public static BlogIndexModel ToIndexModel(this Blog article)
        {
            return new BlogIndexModel()
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                ImageUrl = article.ImageUrl,
                Author = article.Author,
                Date = article.Date,
            };
        }
        public static BlogDetailModel ToDetailModel(this Blog article)
        {
            return new BlogDetailModel()
            {
                Id = article.Id,
                Title = article.Title,
                ImageUrl = article.ImageUrl,
                Content = article.Content,
                Author = article.Author,
                Date = article.Date,
                DateModified = article.DateModified,
            };
        }
        public static BlogUpdateModel ToUpdateModel(this Blog article)
        {
            return new BlogUpdateModel()
            {
                Id = article.Id,
                Title = article.Title,
                ImageUrl = article.ImageUrl,
                Content = article.Content,
                Author = article.Author,
            };
        }

    }
}
