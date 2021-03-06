using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Repositories.Interfaces;
using MyBlog.Repositories;
using MyBlog.Services;
using MyBlog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using MyBlog.Common.Options;
using MyBlog.Common.Logs.Services;
using MyBlog.Middleware;

namespace MyBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ArticlesDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DBConnection")));


            //var cookieExprrTime = Configuration.GetValue<int>("CookieExpirationPeriod");
            //var topRecipesCount = Configuration["SidebarConfig:TopRecipesCount"];


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { 
                options.LoginPath = "/Auth/SignIn"; 
                options.LogoutPath = "/Auth/SignOut";
                options.AccessDeniedPath = "/Auth/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromHours(int.Parse(Configuration["CookieExpirationPeriod"])); // If the user is not active 15secounds it sign out
                //options.ExpireTimeSpan = TimeSpan.FromHours(4); // If the user is not active 15secounds it sign out
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy =>
                {
                    policy.RequireClaim("IsAdmin", "True");
                });
            });

            services.AddControllersWithViews();


            // Configure options
            services.Configure<SidebarConfig>(Configuration.GetSection("SidebarConfig"));

            // Services
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUsersService, UserService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IRatingsService, RatingsService>();
            services.AddTransient<ISidebarService, SidebarService>();
            services.AddTransient<ILogService, LogService>();

            // Repositories
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<ICommentsRepository, CommentsRepository>();
            services.AddTransient<IRatingsRepository, RatingsRepository>();
            //services.AddTransient<IBlogRepository, BlogFileRepository>();
            //services.AddTransient<IBlogRepository, BlogSqlRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Info/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionLoggingMiddleware>();

            app.UseMiddleware<RequestResponseLogMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
