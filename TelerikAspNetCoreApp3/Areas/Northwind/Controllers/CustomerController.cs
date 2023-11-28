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
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async override Task ExecuteResultAsync(ActionContext context)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            var response = context.HttpContext.Response;

            context.ActionDescriptor.DisplayName = "Naser";
            //var stream = context.HttpContext.Request.Body;
            //response.ContentType = "text/html";
        }
    }
}