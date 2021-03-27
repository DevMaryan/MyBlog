﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _userRepository;
        public AuthService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool SignIn(string username, string password, bool IsPersistent, HttpContext httpContext)
        {

            var response = false;
            var user = _userRepository.GetByUsername(username);

            if (user != null && user.Password == password)
            {
                var claims = new List<Claim>()
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("Address", user.Address),
                    new Claim("Email", user.Email)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var authProps = new AuthenticationProperties() { IsPersistent = IsPersistent };

                Task.Run(() => httpContext.SignInAsync(principal)).GetAwaiter().GetResult();
                response = true;
            }
            else
            {
                response = false;
            }
            return response;
        }
        public void SignOut(HttpContext httpContext)
        {
            Task.Run(() => httpContext.SignOutAsync()).GetAwaiter().GetResult();
        }
    }
}