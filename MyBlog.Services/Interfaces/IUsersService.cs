using MyBlog.Models;

namespace MyBlog.Services.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
        User GetDetails(int userId);

        void UpdateUser(User user);
    }
}
