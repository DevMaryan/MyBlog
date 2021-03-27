using Microsoft.AspNetCore.Http;

namespace MyBlog.Services.Interfaces
{
    public interface IAuthService
    {
        bool SignIn(string username, string password, bool IsPersistent, HttpContext httpContext);
        void SignOut(HttpContext httpContext);
    }
}
