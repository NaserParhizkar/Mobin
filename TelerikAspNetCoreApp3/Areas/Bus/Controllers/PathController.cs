using Kendo.Mvc.Mobin.Controllers;
using KendoBus.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebUI.Areas.Bus.Controllers
{
    public class PathController : HtmlManagerController<Path>
    {
        public ActionResult PathView()
        {
            return View();
        }

        public override PartialViewResult EntryForm()
        {
            return base.EntryForm();
        }

        public ActionResult ValidateForm()
        {
            return View();
        }
    }
}
