using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebUI.Areas.Bus.Controllers
{
    public class PathController : Controller
    {
        public ActionResult PathView()
        {
            return View();
        }

        public PartialViewResult EntryForm()
        {
            return PartialView();
        }


        public ActionResult ValidateForm()
        {
            return View();
        }
    }
}
