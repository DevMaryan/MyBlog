using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Services;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        public BlogService _service { get; set; }

        public HomeController()
        {
            _service = new BlogService();
        }
        public IActionResult Index()
        {
            var all_articles = _service.GetAllArticles();
            return View(all_articles);
        }
        public IActionResult Create()
        {
            return View();
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
