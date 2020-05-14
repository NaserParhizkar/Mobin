using Microsoft.AspNetCore.Mvc;
using Mobin.Common.Attributes;
using Northwind.WebUI.Areas.Northwind.Controllers;

namespace Northwind.WebUI.Areas.PDN.Controllers
{
    public class PDNOrderController : Controller
    {
        [Menu(MenuName = "سفارشات")]
        public IActionResult Index()
        {
            return View();
        }
    }
}