using Microsoft.AspNetCore.Mvc;
using MyBlog.Mappings;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult SignIn(string ErrorMessage,string SuccessMessage)
        {
            ViewBag.SuccessMessage = SuccessMessage;
            ViewBag.ErrorMessage = ErrorMessage;
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(SignInModel signInModel, string returnUrl, string SuccessMessage, string ErrorMessage)
        {
            ViewBag.SuccessMessage = SuccessMessage;
            ViewBag.ErrorMessage = ErrorMessage;
            if (ModelState.IsValid)
            {
                var response = _authService.SignIn(signInModel.Username, signInModel.Password, signInModel.IsPersistent,  HttpContext);

                if (response == true)
                {
                    if(returnUrl == null)
                    {
                        return RedirectToAction("Index", "Home", new { SuccessMessage = $"User {signInModel.Username} is logged in." });
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }

                }
                else
                {
                    return RedirectToAction("SignIn", "Auth", new { ErrorMessage = "Credentials not valid." });
                }
            }
            else
            {
                return View(signInModel);
            }
        }
        // User SignOut
        
        public IActionResult SignOut()
        {
            _authService.SignOut(HttpContext);
            return RedirectToAction("Index", "Home");
        }

        // User SignUp
        [HttpGet]
        public IActionResult SignUp(string SuccessMessage, string ErrorMessage)
        {
            ViewBag.SuccessMessage = SuccessMessage;
            ViewBag.ErrorMessage = ErrorMessage;
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpModel signUpModel, string ErrorMessage, string SuccessMessage)
        {
            ViewBag.SuccessMessage = SuccessMessage;
            ViewBag.ErrorMessage = ErrorMessage;

            if (ModelState.IsValid)
            {
                var user = signUpModel.ToModel();
                var response = _authService.SignUp(user);

                if (response == true)
                {
                    return RedirectToAction("SignIn", new { SuccessMessage = $"User {signUpModel.Username} is registered." });
                }
                else
                {
                    ViewBag.ErrorMessage = "The username already exists! Choose another please.";
                    return View(signUpModel);
                }
            }

            return View(signUpModel);
        }


        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
