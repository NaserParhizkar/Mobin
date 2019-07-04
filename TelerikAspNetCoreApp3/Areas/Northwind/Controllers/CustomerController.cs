using Microsoft.AspNetCore.Mvc;
using Mobin.Common.Attributes;
using System.Threading.Tasks;

namespace Northwind.WebUI.Areas.Northwind.Controllers
{
    public class CustomerController : MyController
    {
        [Menu(MenuName = "مشتریان")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }

    public class MyController : Controller
    {
        public ParnetPartialViewResult ParnetPartialViewResult()
        {
            ParnetPartialViewResult partial = new ParnetPartialViewResult();
            partial.ViewName = "MyPartial";
            return partial;
        }
    }



    public class ParnetPartialViewResult : PartialViewResult
    {
        public async override Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;

            context.ActionDescriptor.DisplayName = "Naser";
            //var stream = context.HttpContext.Request.Body;
            //response.ContentType = "text/html";
        }
    }
}