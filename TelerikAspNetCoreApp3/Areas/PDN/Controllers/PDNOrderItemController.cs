using Microsoft.AspNetCore.Mvc;
using Northwind.WebUI.Areas.Northwind.Controllers;

namespace Northwind.WebUI.Areas.PDN.Controllers
{
    public class PDNOrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}