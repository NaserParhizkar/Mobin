using Kendo.Mvc.Mobin.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;

namespace Kendo.Mvc.UI.Fluent
{
    public partial class WindowBuilder
    {
        /// <summary>
        /// Sets the Url, which will be requested to return the content. 
        /// </summary>
        /// <param name="controllerAction">LambdaExpression point to specefied PartialView</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Window()
        ///             .Name("Window")
        ///             .LoadContentFrom(t => t.EntryForm())
        /// %&gt;
        /// </code>
        /// </example>
        public WindowBuilder LoadContentFrom<TController>(Expression<Action<TController>> controllerAction) where TController : Controller
        {
            var routeValueDisctionary = ExpressionHelper.GetRouteValuesFromExpression<TController>(controllerAction);
            string controllerName = routeValueDisctionary["Controller"].ToString();
            string actionName = routeValueDisctionary["Action"].ToString();

            return LoadContentFrom(actionName, controllerName, (object)null);
        }
    }
}