using MyBlog.Services.Interfaces;
using MyBlog.Repositories.Interfaces;
using MyBlog.Models;
using MyBlog.Common.Exceptions;
using System.Collections.Generic;

namespace MyBlog.Services
{
    public class UserService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User GetDetails(string userId)
        {
            return _usersRepository.GetById(int.Parse(userId));
        }

        public User GetDetails(int userId)
        {
            return _usersRepository.GetById(userId);
        }

        public void UpdateUser(User user)
        {
            var user_update = _usersRepository.GetById(user.Id);
            if (user_update != null)
            {
                user_update.Id = user.Id;
                user_update.Email = user.Email;
                user_update.Address = user.Address;
                user_update.IsAdmin = user.IsAdmin;

                _usersRepository.Update(user_update);
            }
            else
            {
                throw new NotFoundException($"The movie with id {user_update.Id} was not found");
            }
        }
        public void DeleteUser(int id)
        {
            var user = _usersRepository.GetById(id);
            if (user != null)
            {
                _usersRepository.Delete(user);
            }

        }

        public List<User> GetAllUsers()
        {
            return _usersRepository.GetAll();
        }

        public void IsAdmin(User user)
        {
            var user_update = _usersRepository.GetById(user.Id);
            if (user_update != null)
            {
                user_update.IsAdmin = user.IsAdmin;

                _usersRepository.SetIsAdmin(user_update);
            }
            else
            {
                throw new NotFoundException($"User with id {user_update.Id} was not found");
            }

        }

        public bool ToggleIsAdmin(int id)
        {
            var response = false;
            var selected_user = _usersRepository.GetById(id);
            if(selected_user != null)
            {
                selected_user.IsAdmin = !selected_user.IsAdmin;
                _usersRepository.Update(selected_user);
                response = true;
            }
            else
            {
                response = false;
            }
            return response;
        }
    }
}
