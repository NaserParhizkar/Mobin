using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebUI.Controllers
{
    public class PersianDateController : Controller
    {
        public ActionResult Index()
        {



            return View();
        }


        public PartialViewResult EntryForm()
        {
            return PartialView();
        }
    }
}