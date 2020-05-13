
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Mobin.Controllers;
using Kendo.Mvc.UI;
using KendoBus.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using Northwind.Service;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Northwind.WebUI.Areas.Bus.Controllers
{
    public class PathApiController : CrudController<Path>
    {
        private readonly IPathService pathService;
        public PathApiController(IPathService _pathService) : base(_pathService)
        {
            pathService = _pathService;
        }

        public override async System.Threading.Tasks.Task<object> Read([DataSourceRequest] DataSourceRequest request)
        {
            var query = pathService.GetAllAsQueryable();
            return await query.ToDataSourceResultAsync(request);
        }
    }


    public class ValidateUserNameAttribute : ActionFilterAttribute
    {
        public string inputName = "";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!string.IsNullOrEmpty(inputName) && inputName == "Hello")
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            else
                context.Result = new UnauthorizedObjectResult("Unauthorized user");

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}