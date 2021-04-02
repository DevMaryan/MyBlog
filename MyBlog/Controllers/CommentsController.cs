using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(CommentCreateModel commentCreateModel)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _commentsService.Add(commentCreateModel.Comment, commentCreateModel.ArticleId, userId);

            return RedirectToAction("Detail", "Home", new { id = commentCreateModel.ArticleId });
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var user = int.Parse(User.FindFirst("id").Value);

            var comment = _commentsService.GetCommentId(id);
            var the_user = comment.UserId;
            if (comment != null && user == the_user)
            {
                _commentsService.DeleteComment(comment);
                return RedirectToAction("Detail", "Home", new { id = comment.ArticleId });
            }
            else
            {
                return RedirectToAction("Error", "Info");
            }

        }
    }
}
