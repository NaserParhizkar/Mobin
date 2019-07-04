using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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