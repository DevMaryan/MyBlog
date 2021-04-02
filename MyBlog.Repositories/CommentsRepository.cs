using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class CommentsRepository : BaseRepository<Comment>, ICommentsRepository
    {
        public CommentsRepository(ArticlesDbContext context) : base(context)
        {

        }

        public List<Comment> GetCommentByUserId(int userId)
        {
            var comments = _context.Comments.Where(x => x.UserId == userId).ToList();
            return comments;
        }

        public void DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();


        }

        public Comment GetCommentById(int id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == id);

        }
    }
}