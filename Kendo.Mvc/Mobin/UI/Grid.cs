using Kendo.Mvc.Mobin;
using Mobin.Common;
using Mobin.Common.Expressions;
using Mobin.ExpressionJsonSerializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Mobin Kendo UI Grid component extending
    /// </summary>
    public partial class Grid<T> where T : class 
    {
        protected override void MobinSettings()
        {
            if (this.DataSource.AutoReadData)
            {
                SerialSelectorColumnsAsJson();
            }
            base.MobinSettings();
        }

        private void SerialSelectorColumnsAsJson()
        {
            var defaultPath = String.Join("/", new[] { "wwwroot", "expressions" });
            var routePath = String.Join("/", this.ViewContext.RouteData.Values.Values.ToArray());

            var expressionComponentDirectory = System.IO.Directory.CreateDirectory($"{defaultPath}/{routePath}");
            var expressionComponentFileName = this.Name + ".json";

            var filePath_Name = String.Join('/', expressionComponentDirectory.FullName, expressionComponentFileName);

            if (!System.IO.File.Exists(filePath_Name))
            {
                List<Expression> expressionColumns = new List<Expression>();
                foreach (var col in this.Columns)
                {
                    var expression = (Expression)col.GetPropertyValue("Expression");
                    if (expression != null)
                        expressionColumns.Add(expression);
                }

                var lambdaExpression = expressionColumns.GetLambdaExpression<T>();

                ExpressionSaver.SerialExpressionAsJson<T>(lambdaExpression, filePath_Name, typeof(T).Assembly);
            }

            // Set component key and value 
            if (!ComponentExpressionPath.ExpressionPath.Values.Contains(filePath_Name))
            {
                var componentId = Guid.NewGuid();
                ComponentExpressionPath.ExpressionPath.Add(componentId,filePath_Name);
                this.DataSource.ComponentId = componentId;
            }
        }
    }
}