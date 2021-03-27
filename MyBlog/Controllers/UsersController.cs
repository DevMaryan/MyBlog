using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Services.Interfaces;
using MyBlog.Common.Exceptions;
using System;
using MyBlog.Mappings;
using MyBlog.ViewModels;

namespace MyBlog.Controllers
{
    public class UsersController : Controller
    {

        private readonly IUsersService _userService;
        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }
        [Authorize]
        public IActionResult Details(string successMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            var userId = User.FindFirst("Id").Value;
            var user = _userService.GetDetails(userId);

            if (user == null)
            {
                return RedirectToAction("Error", "Info");
            }
            return View(user.ToDetailsModel());
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _userService.GetDetails(id);
            if (user == null)
            {
                return RedirectToAction("Index", "Home", new { ErrorMessage = "User not found." });
            }
            return View(user.ToUpdateModel());
        }

        [HttpPost]
        public IActionResult Update(UserUpdateModel user_id, string successMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            if (ModelState.IsValid)
            {
                try
                {
                    var the_user = _userService.GetDetails(user_id.Id);
                    _userService.UpdateUser(user_id.ToModel());
                    return RedirectToAction("Details", new { SuccessMessage = "Your profile is updated." });
                }
                catch (NotFoundException ex)
                {
                    return RedirectToAction("Admin", new { ErrorMessage = ex.Message });
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", "Info");
                }
            }
            return View(user_id);
        }
    }
}
