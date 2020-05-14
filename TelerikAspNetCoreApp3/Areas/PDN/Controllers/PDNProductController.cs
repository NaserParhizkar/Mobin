using Microsoft.AspNetCore.Mvc;
using Mobin.Common.Attributes;
using Northwind.WebUI.Areas.Northwind.Controllers;
using System.Threading.Tasks;

namespace Northwind.WebUI.Areas.PDN.Controllers
{
    public class PDNProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}