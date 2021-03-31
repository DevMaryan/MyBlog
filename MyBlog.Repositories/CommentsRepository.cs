using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories
{
    public class CommentsRepository :  BaseRepository<Comment>, ICommentRepository
    {
        public CommentsRepository(ArticlesDbContext context) : base(context)
        {

        }
    }
}
