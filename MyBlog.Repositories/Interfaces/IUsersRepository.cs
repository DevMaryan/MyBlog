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
    }
}
