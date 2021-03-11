using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class Info : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
