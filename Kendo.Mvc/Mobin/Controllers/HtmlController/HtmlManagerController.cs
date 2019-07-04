using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kendo.Mvc.Mobin.Controllers.HtmlController
{
    public class HtmlManagerController<TModel> : Controller
    {
        public virtual PartialViewResult ParentInsertForm()
        {
            return PartialView();
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
