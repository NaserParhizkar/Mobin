using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebUI.Areas.Northwind.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}