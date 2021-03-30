using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Services.Interfaces;
using MyBlog.Common.Exceptions;
using System;
using MyBlog.Mappings;
using MyBlog.ViewModels;
using System.Linq;

namespace MyBlog.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {

        private readonly IUsersService _userService;
        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        public IActionResult Details(string SuccessMessage,string ErrorMessage)
        {
            ViewBag.SuccessMessage = SuccessMessage;
            ViewBag.ErrorMessage = ErrorMessage;
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
                    if (Convert.ToBoolean(User.FindFirst("IsAdmin").Value))
                    {
                        return RedirectToAction("Admin", new { SuccessMessage = $"The {the_user.Username} is updated." });
                    }
                    else
                    {
                        return RedirectToAction("Details", new { SuccessMessage = "Your profile is updated." });
                    }
                    
                }
                catch (NotFoundException ex)
                {
                    return RedirectToAction("Admin", new { ErrorMessage = ex.Message });
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Info");
                }
            }
            return View(user_id);
        }

        // User Admin Panel
        public IActionResult Admin(string SuccessMessage, string ErrorMessage)
        {
            ViewBag.SuccessMessage = SuccessMessage;
            ViewBag.ErrorMessage = ErrorMessage;
            var all_users = _userService.GetAllUsers();

            var viewModels = all_users.Select(x => x.ToAdminModel()).ToList();


            return View(viewModels);
        }

        // User Delete
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return RedirectToAction("Admin", new { SuccessMessage = "User deleted." });
            }
            catch (Exception)
            {
                return RedirectToAction("Info", "Error");
            }
        }
    }
}
