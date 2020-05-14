using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefahPardisAPI.Utilities
{
    public class ValidateApiAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var asd = context.Filters;

            //if (!context.ModelState.IsValid)
            //{
            //    var result = new Dictionary<string, string>();
            //    foreach (var key in context.ModelState.Keys)
            //    {
            //        result.Add(key, String.Join(", ", context.ModelState[key].Errors.Select(p => p.ErrorMessage)));
            //    }

            //    // 422 Unprocessable Entity Explained
            //    context.Result = new ObjectResult(result) { StatusCode = 422 };
            //}
        }
    }

    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        private string inputItem = null;
        private string[] _acceptedItems = new string[] { "Hello" };
        public MyActionFilterAttribute(string item)
        {
            inputItem = item;
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {

        }
    }
}
