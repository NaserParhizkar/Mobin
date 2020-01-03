using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Kendo.Mvc.Mobin.Common
{
    internal static class ExpressionHelper
    {

        public static RouteValueDictionary GetRouteValuesFromExpression<TController>(Expression<Action<TController>> action)
            where TController : Controller
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            MethodCallExpression methodCallExpression = action.Body as MethodCallExpression;
            if (methodCallExpression == null)
            {
                throw new ArgumentException();
                //throw new ArgumentException(MvcResources.ExpressionHelper_MustBeMethodCall, "action");
            }
            string name = typeof(TController).Name;
            if (!name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException();
                //throw new ArgumentException(MvcResources.ExpressionHelper_TargetMustEndInController, "action");
            }
            name = name.Substring(0, name.Length - "Controller".Length);
            if (name.Length == 0)
            {
                throw new ArgumentException();
                //throw new ArgumentException(MvcResources.ExpressionHelper_CannotRouteToController, "action");
            }
            string targetActionName = GetTargetActionName(methodCallExpression.Method);
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary.Add("Controller", name);
            routeValueDictionary.Add("Action", targetActionName);
            AreaAttribute areaAttribute = typeof(TController).GetCustomAttributes(typeof(AreaAttribute), inherit: true).FirstOrDefault() as AreaAttribute;
            if (areaAttribute != null)
            {
                string area = areaAttribute.RouteKey == "Area" ? areaAttribute.RouteValue : "";
                routeValueDictionary.Add("Area", area);
            }
            AddParameterValuesFromExpressionToDictionary(routeValueDictionary, methodCallExpression);
            return routeValueDictionary;
        }

        private static void AddParameterValuesFromExpressionToDictionary(RouteValueDictionary rvd, MethodCallExpression call)
        {
            ParameterInfo[] parameters = call.Method.GetParameters();
            if (parameters.Length > 0)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    Expression expression = call.Arguments[i];
                    object obj = null;
                    ConstantExpression constantExpression = expression as ConstantExpression;
                    //rvd.Add(value: (constantExpression == null) ? CachedExpressionCompiler.Evaluate(expression) : constantExpression.Value, key: parameters[i].Name);
                }
            }
        }

        private static string GetTargetActionName(MethodInfo methodInfo)
        {
            string name = methodInfo.Name;
            if (methodInfo.IsDefined(typeof(NonActionAttribute), inherit: true))
            {
                throw new InvalidOperationException();
                //throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, MvcResources.ExpressionHelper_CannotCallNonAction, new object[1]
                //{
                //    name
                //}));
            }
            ActionNameAttribute val = methodInfo.GetCustomAttributes(typeof(ActionNameAttribute), inherit: true).OfType<ActionNameAttribute>().FirstOrDefault();
            if (val != null)
            {
                return val.Name;
            }
            if (methodInfo.DeclaringType.IsSubclassOf(typeof(Controller)))
            {
                if (name.EndsWith("Async", StringComparison.OrdinalIgnoreCase))
                {
                    return name.Substring(0, name.Length - "Async".Length);
                }
                if (name.EndsWith("Completed", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException();
                    //    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, MvcResources.ExpressionHelper_CannotCallCompletedMethod, new object[1]
                    //    {
                    //name
                    //    }));
                }
            }
            return name;
        }
    }
}
