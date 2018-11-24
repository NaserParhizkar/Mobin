using Mobin.Common;
using Mobin.Common.Expressions;
using Mobin.ExpressionJsonSerializer;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Mobin Kendo UI Grid component extending
    /// </summary>
    public partial class Grid<T>
    {
        protected override void MobinSettings()
        {
            if (this.DataSource.AutoReadData)
            {
                var path = this.ViewContext;
                SerialSelectorColumnsAsJson(@"G:\JSON\lambdaExpression7.json");
            }

            base.MobinSettings();
        }

        private void SerialSelectorColumnsAsJson(string path)
        {
            List<Expression> expressionColumns = new List<Expression>();
            foreach (var col in this.Columns)
            {
                var expression = (Expression)col.GetPropertyValue("Expression");
                if (expression != null)
                    expressionColumns.Add(expression);
            }
            var lambdaExpression = expressionColumns.GetLambdaExpression<T>();

            ExpressionSaver.SerialExpressionAsJson<T>(lambdaExpression, path, typeof(T).Assembly);
        }
    }
}