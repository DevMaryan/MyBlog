using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Services;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
using MyBlog.Mappings;
using MyBlog.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using MyBlog.Common.Logs.Models;
using MyBlog.Common.Logs.Services;
using MyBlog.Common.Logs;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogService _logService;
        public IBlogService _service { get; set; }

        public ISidebarService _sidebarService { get; set; }

        public HomeController(IBlogService service, ISidebarService sidebarService, ILogService logService)
        {
            _service = service;
            _sidebarService = sidebarService;
            _logService = logService;
        }
        // Index Page - Search as well
        public IActionResult Index(string title, string successMessage,string ErrorMessage)
        {
            ViewBag.ErrorMessage = ErrorMessage;
            ViewBag.SuccessMessage = successMessage;

            var all_articles = _service.GetArticleByTitle(title);

            var IndexDataModel = new BlogIndexDataModel();

            var articlesIndexModels = all_articles.Select(x => x.ToIndexModel()).ToList();

            IndexDataModel.IndexModels = articlesIndexModels;
            IndexDataModel.SidebarData = _sidebarService.GetSidebarData();

            return View(IndexDataModel);
        }

        // Create Article
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(BlogCreateModel article)
        {
            if (ModelState.IsValid)
            {
                var domainModel = article.ToModel();
                _service.CreateArticle(domainModel);

                // Log Service
                var userId = User.FindFirst("Id");
                var logData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = $"User with id {userId} created article {article.Title}" };
                _logService.Log(logData);

                return RedirectToAction("Index", new { SuccessMessage = $"Article {article.Title} successfully added." });
            }
            return View(article);
        }
        // Delete Articles
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                // Find the Article title
                var title = _service.GetArticleById(id);

                // Log Service -> Send the title and the User to Logs
                var userId = User.FindFirst("Id");
                var logData = new LogData() { Type = LogType.Warning, DateCreated = DateTime.Now, Message = $"User with id {userId} deleted article {title.Title}" };
                _logService.Log(logData);


                // Delete the article
                _service.DeleteArticle(id);

                return RedirectToAction("Admin", new { SuccessMessage = $"Article with id {id} has been deleted." });
            }
            catch(NotFoundException ex)
            {
                return RedirectToAction("Admin", new { ErrorMessage = ex.Message });
            }
            catch(Exception)
            {
                return RedirectToAction("Error", "Info");
            }
        }

        // Update Articles - GET Method
        [Authorize]
        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var update_article = _service.GetArticleById(id);

                if (update_article == null)
                {
                    return RedirectToAction("Error", "Info");
                }
                return View(update_article.ToUpdateModel());
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("Admin", new { ErrorMessage = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Info");
            }
        }
        [Authorize]
        // Update Articles
        [HttpPost]
        public IActionResult Update(BlogUpdateModel article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateArticle(article.ToModel());

                    return RedirectToAction("Admin", new { SuccessMessage = $"Article {article.Title} updated successfully." });
                }
                catch (NotFoundException ex)
                {
                    return RedirectToAction("Admin", new { ErrorMessage = ex.Message });
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Info");
                }
            }
            return View(article);
        }

        // Detail View ARticle

        public IActionResult Detail(int id)
        {
            try
            {
                var select_article = _service.GetArticleDetails(id);
          
                if(select_article == null)
                {
                    return RedirectToAction("Error", "Info");
                }

                var blogDetailsDataModel = new BlogDetailDataModel();

                blogDetailsDataModel.BlogDetail = select_article.ToDetailModel();

                blogDetailsDataModel.blogSidebarData = _sidebarService.GetSidebarData();


                //var viewModel = select_article.ToDetailModel();



                return View(blogDetailsDataModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Info", new { Errormessage = ex.Message });
            }
        }

        // Admin Page
        [Authorize]
        public IActionResult Admin(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;

            var all_articles = _service.GetAllArticles();

            var viewModels = all_articles.Select(x => x.ToAdminModel()).ToList();

            return View(viewModels);
        }

        public IActionResult Like(int id)
        {
            try
            {
                var select_article = _service.Like(id);

                if (select_article)
                {
                    return RedirectToAction("Detail", new { id = id });
                }
                else
                {
                    return RedirectToAction("Admin", new { SuccessMessage = "User not found." });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Admin", new { ErrorMessage = "Unexpected happened." });
            }
        }


    }
}
