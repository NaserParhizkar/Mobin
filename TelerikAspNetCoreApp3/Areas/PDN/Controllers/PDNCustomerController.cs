using Microsoft.AspNetCore.Mvc;
using Mobin.Common.Attributes;
using Northwind.WebUI.Areas.Northwind.Controllers;
using System.Threading.Tasks;

namespace Northwind.WebUI.Areas.PDN.Controllers
{
    public class PDNCustomerController : Controller
    {
        [Menu(MenuName = "مشتریان")]
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