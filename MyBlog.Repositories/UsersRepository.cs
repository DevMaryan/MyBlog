﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyBlog.Repositories.Interfaces;
using MyBlog.Models;

namespace MyBlog.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ArticlesDbContext _context;
        public UsersRepository(ArticlesDbContext context)
        {
            _context = context;
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }
        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public void UpdateUser(User user)
        {

            _context.Users.Update(user);
            _context.SaveChanges();

        }
    }
}