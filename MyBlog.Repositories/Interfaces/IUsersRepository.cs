using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;

namespace MyBlog.Repositories.Interfaces
{
    public interface IUsersRepository : IBaseRepository<User>
    {
        User GetByUsername(string username);

        bool CheckIfExists(string username, string email);

        void SetIsAdmin(User user);

    }
}
