using MyBlog.Models;
using MyBlog.ViewModels;

namespace MyBlog.Mappings
{
    public static class ViewModelExtensions
    {
        public static Blog ToModel(this BlogCreateModel viewModel)
        {
            return new Blog
            {
                Title = viewModel.Title,
                ImageUrl = viewModel.ImageUrl,
                Author = viewModel.Author,
                Content = viewModel.Content,

            };
        }
        public static Blog ToModel(this BlogUpdateModel viewModel)
        {
            return new Blog
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                ImageUrl = viewModel.ImageUrl,
                Author = viewModel.Author,
                Content = viewModel.Content,


            };
        }
        public static User ToModel(this UserUpdateModel viewModel)
        {
            return new User
            {
                Id = viewModel.Id,
                Address = viewModel.Address,
                Email = viewModel.Email,
                IsAdmin = viewModel.IsAdmin,
            };
        }

        public static User ToModel(this UserAdminModel user)
        {
            return new User()
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                Username = user.Username,
                IsAdmin = user.IsAdmin,
                DateCreated = user.DateCreated,
            };

        }

        public static User ToModel(this SignUpModel user)
        {
            return new User()
            {
                Password = user.Password,
                Address = user.Address,
                Email = user.Email,
                Username = user.Username,

            };
        }
    }
}
