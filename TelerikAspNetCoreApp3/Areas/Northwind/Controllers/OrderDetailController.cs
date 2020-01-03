using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebUI.Areas.Northwind.Controllers
{
    public class OrderDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult TestExpression()
        {
            return View();
        }
    }
}