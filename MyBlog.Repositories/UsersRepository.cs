using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyBlog.Repositories.Interfaces;
using MyBlog.Models;

namespace MyBlog.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        public UsersRepository(ArticlesDbContext context) : base(context)
        {
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }


        public bool CheckIfExists(string username, string email)
        {
            return _context.Users.Any(x => x.Username == username || x.Email == email);
        }



        public void SetIsAdmin(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

    }
}
