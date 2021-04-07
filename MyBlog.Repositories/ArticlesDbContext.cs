using Microsoft.EntityFrameworkCore;
using MyBlog.Models;

namespace MyBlog.Repositories
{
    public class ArticlesDbContext : DbContext
    {
        public ArticlesDbContext(DbContextOptions<ArticlesDbContext> options): base(options)
        {

        }
        public DbSet<Blog> Articles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
