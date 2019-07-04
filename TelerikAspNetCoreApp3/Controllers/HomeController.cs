using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Repository;

namespace Northwind.WebUI.Controllers
{
    [Display(Name = "صفحات اصلی")]
    public class HomeController : Controller
    {
        [Display(Name = "خانه")]
        public IActionResult Index()
        {
            return View();
        }

        [Display(Name = "درباره ی ما")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Display(Name = "تماس با ما")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Display(Name = "خطا")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
