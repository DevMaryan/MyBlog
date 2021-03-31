using MyBlog.Models;
using System.Collections.Generic;

namespace MyBlog.Services.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
        User GetDetails(int userId);

        void UpdateUser(User user);

        List<User> GetAllUsers();
        void DeleteUser(int id);

        void IsAdmin(User user);
        bool ToggleIsAdmin(int id);
    }
}
