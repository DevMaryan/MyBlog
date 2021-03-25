using Microsoft.AspNetCore.Http;

namespace MyBlog.Services.Interfaces
{
    public interface IAuthService
    {
        bool SignIn(string username, string password, HttpContext httpContext);
    }
}
