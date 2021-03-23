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
    }
}
