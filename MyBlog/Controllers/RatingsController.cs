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
    public class RatingsController : Controller
    {
        private readonly IRatingsService _ratingService;


        public RatingsController(IRatingsService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(BlogRatingModel blogRatingModel)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _ratingService.Add(blogRatingModel.Score, blogRatingModel.BlogId, userId);

            return RedirectToAction("Detail", "Home", new { id = blogRatingModel.BlogId });
        }


    }
}
