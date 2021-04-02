using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public void Add(string comment, int articleId, int userId)
        {
            var newComment = new Comment()
            {
                Message = comment,
                DateCreated = DateTime.Now,
                ArticleId = articleId,
                UserId = userId
            };

            _commentsRepository.Add(newComment);
        }
        public void DeleteComment(Comment comment)
        {

            _commentsRepository.DeleteComment(comment);
        }

        public Comment GetCommentId(int id)
        {
            return _commentsRepository.GetCommentById(id);
        }

    }
}
