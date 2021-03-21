using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Services;
using MyBlog.Services.Interfaces;
using MyBlog.Models;
using MyBlog.Common.Exceptions;

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
        public IActionResult Index(string title, string successMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            var all_articles = _service.GetArticleByTitle(title);
            return View(all_articles);
        }

        // Create Article
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog article)
        {
            if (ModelState.IsValid)
            {
                _service.CreateArticle(article);
                return RedirectToAction("Index", new { SuccessMessage = "Article successfully added." });
            }
            return View(article);
        }
        // Delete Articles
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteArticle(id);
                return RedirectToAction("Admin", new { SuccessMessage = "Article is deleted successfully." });
            }
            catch(NotFoundException ex)
            {
                return RedirectToAction("Admin", new { ErrorMessage = ex.Message });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Info");
            }
        }

        // Update Articles - GET Method
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
                return View(update_article);
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("Admin", new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Info");
            }
        }

        // Update Articles
        [HttpPost]
        public IActionResult Update(int id, string title, string author, string content, string imageurl, DateTime date)
        {
            try
            {
                var update_article = _service.GetArticleById(id);

                if (update_article == null)
                {
                    return RedirectToAction("Error", "Info");
                }
                update_article.Author = author;
                update_article.Content = content;
                update_article.Date = date;
                update_article.ImageUrl = imageurl;
                update_article.Title = title;
                _service.UpdateArticle(update_article);

                return RedirectToAction("Admin", new { SuccessMessage = "Article is updated successfully." });
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("Admin", new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Info");
            }
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
                return View(select_article);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Info", new { Errormessage = ex.Message });
            }
        }

        // Admin Page
        public IActionResult Admin(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            var all_articles = _service.GetAllArticles();
            return View(all_articles);
        }
    }
}
