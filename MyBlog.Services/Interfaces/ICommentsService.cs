using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services.Interfaces
{
    public interface ICommentsService
    {
        void Add(string comment, int recipeId, int userId);

        Comment GetCommentId(int id);

        void DeleteComment(Comment comment);
    }
}
