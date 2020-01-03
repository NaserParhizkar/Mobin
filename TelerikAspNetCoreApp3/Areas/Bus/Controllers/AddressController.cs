using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebUI.Areas.Bus.Controllers
{
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}