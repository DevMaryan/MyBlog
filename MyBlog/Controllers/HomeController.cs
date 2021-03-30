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

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        public IBlogService _service { get; set; }

        public HomeController(IBlogService service)
        {
            _service = service;
        }
        // Index Page - Search as well
        public IActionResult Index(string title, string successMessage,string ErrorMessage)
        {
            ViewBag.ErrorMessage = ErrorMessage;
            ViewBag.SuccessMessage = successMessage;
            var all_articles = _service.GetArticleByTitle(title);

            var articlesIndexModels = all_articles.Select(x => x.ToIndexModel()).ToList();

            return View(articlesIndexModels);
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
                _service.DeleteArticle(id);
                var title = _service.GetArticleById(id);
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
                var select_article = _service.GetArticleById(id);

                if(select_article == null)
                {
                    return RedirectToAction("Error", "Info");
                }
                return View(select_article.ToDetailModel());
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
    }
}
