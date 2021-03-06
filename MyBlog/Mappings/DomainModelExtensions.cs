using MyBlog.Models;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Views = article.Views,
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
                Like = article.Likes,
                Comments = article.Comments.Select(x => x.ToCommentModel()).ToList(),
                Ratings = article.Ratings.Select(x => x.ToRatingModel()).ToList(),
                Views = article.Views,
            };
        }
        public static BlogCommentModel ToCommentModel(this Comment comment)
        {
            return new BlogCommentModel
            {
                Id = comment.Id,
                Message = comment.Message,
                DateCreated = comment.DateCreated,
                Username = comment.User.Username
            };
        }
        public static BlogRatingModel ToRatingModel(this Rating score)
        {
            return new BlogRatingModel
            {
                Id = score.Id,
                Score = score.Score,
                BlogId = score.BlogId,
                Username = score.User.Username
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
        public static UserDetailsModel ToDetailsModel(this User user)
        {
            return new UserDetailsModel()
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                Username = user.Username,
            };
        }
        public static UserUpdateModel ToUpdateModel(this User user)
        {
            return new UserUpdateModel()
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
            };
        }

        public static UserAdminModel ToAdminModel(this User user)
        {
            return new UserAdminModel()
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                Username = user.Username,
                IsAdmin = user.IsAdmin,
                DateCreated = user.DateCreated,
            };
        }

        public static BlogSidebarModel ToBlogSideBarModel(this Blog article)
        {
            return new BlogSidebarModel
            {
                Id = article.Id,
                Title = article.Title,
                ImageUrl = article.ImageUrl,
                Views = article.Views,
                DateCreated = article.Date
            };
        }

    }
}
