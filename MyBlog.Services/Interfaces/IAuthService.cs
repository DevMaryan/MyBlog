using Microsoft.AspNetCore.Http;
using MyBlog.Models;

namespace MyBlog.Services.Interfaces
{
    public interface IAuthService
    {
        bool SignIn(string username, string password, bool IsPersistent, HttpContext httpContext);
        bool SignUp(User user);

        void SignOut(HttpContext httpContext);
    }
}
