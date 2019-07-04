using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kendo.Mvc.Mobin.Common
{
    public static class ExpressionDefaultFileAddress
    {
        private readonly static string defaultPath = String.Join("/", new[] { "wwwroot", "expressions" });

        public static string GetDefaultfilePathName(string componentName,ViewContext viewContext)
        {
            var routePath = String.Join("/", viewContext.RouteData.Values.Values.ToArray());
            var widgetExpressionDirectory = System.IO.Directory.CreateDirectory($"{defaultPath}/{routePath}");
            var widgetExpressionFileName = componentName + ".json";
            return String.Join('/', widgetExpressionDirectory.FullName, widgetExpressionFileName);
        }
    }
}
