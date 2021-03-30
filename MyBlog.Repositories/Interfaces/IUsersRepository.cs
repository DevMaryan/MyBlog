using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;

namespace MyBlog.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User GetByUsername(string username);
        User GetById(int userId);
        void UpdateUser(User user);
        List<User> GetAll();
        void Delete(User user);
        bool CheckIfExists(string username, string email);
        void Add(User newUser);
        void SetIsAdmin(User user);

    }
}
