using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyBlog.Repositories.Interfaces;
using MyBlog.Models;

namespace MyBlog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ArticlesDbContext _context;
        public UserRepository(ArticlesDbContext context)
        {
            _context = context;
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
