using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebUI.Areas.Northwind.Controllers
{
    public class OrderDetailController : Controller
    {
        public IActionResult Index() => View();
        public ViewResult TestExpression() => View();
    }
}