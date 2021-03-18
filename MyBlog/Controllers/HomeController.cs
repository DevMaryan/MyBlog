using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Services;
using MyBlog.Services.Interfaces;
using MyBlog.Models;

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
        public IActionResult Index(string title)
        {
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
                return RedirectToAction("Index");
            }
            return View(article);
        }
        // Delete Articles
        public IActionResult Delete(Blog article)
        {
            _service.DeleteArticle(article);
            return RedirectToAction("Index");
        }

        // Update Articles
        public IActionResult Update()
        {
            return View();
        }

        // Detail View ARticle
       
        public IActionResult Detail(int id)
        {
            var select_article = _service.GetArticleById(id);
            if(select_article == null)
            {
                return RedirectToAction("Error", "Info");
            }
            return View(select_article);
        }

        // Admin Page
        public IActionResult Admin()
        {

            var all_articles = _service.GetAllArticles();
            return View(all_articles);
        }
    }
}
