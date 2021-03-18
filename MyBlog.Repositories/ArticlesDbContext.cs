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
    }
}
