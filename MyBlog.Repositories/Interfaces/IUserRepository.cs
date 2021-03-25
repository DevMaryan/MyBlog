using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;

namespace MyBlog.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
    }
}
