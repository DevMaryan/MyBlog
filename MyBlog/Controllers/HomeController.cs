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
        public IActionResult Index()
        {
            var all_articles = _service.GetAllArticles();
            return View(all_articles);
        }
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
        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var select_article = _service.GetArticleById(id);
            if(select_article == null)
            {
                return RedirectToAction("Error", "Info");
            }
            return View(select_article);
        }

        public IActionResult Admin()
        {

            var all_articles = _service.GetAllArticles();
            return View(all_articles);
        }
    }
}
