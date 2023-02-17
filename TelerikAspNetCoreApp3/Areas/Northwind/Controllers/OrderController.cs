using Microsoft.AspNetCore.Mvc;
using Mobin.Common.Attributes;

namespace Northwind.WebUI.Areas.Northwind.Controllers
{
    public class OrderController : Controller
    {
        [Menu(MenuName = "سفارشات")]
        public IActionResult Index() => View(); 
        public IActionResult SearchInputs() => View();
    }
}