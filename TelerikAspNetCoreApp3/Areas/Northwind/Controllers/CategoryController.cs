using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebUI.Areas.Northwind.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index() => View();
    }
}