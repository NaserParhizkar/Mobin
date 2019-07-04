using Kendo.Mvc.Mobin;
using Kendo.Mvc.Mobin.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public partial class Grid<T>
    {
        protected override void MobinProcessSettings()
        {
            if (DataSource.AutoMakeQueryExpression)
            {
                DataSource.WidgetId = Guid.NewGuid();
                SerialSelectorColumnsAsJson();
            }
            base.MobinProcessSettings();
        }

        private void SerialSelectorColumnsAsJson()
        {
            var filePath_Name = ExpressionDefaultFileAddress.GetDefaultfilePathName(Name, ViewContext);
            List<Expression> fetchFields = new List<Expression>();
            var ids = this.DataSource.Schema.Model.Id;
            var keyExpression = (Expression)ids?.GetPropertyValue(nameof(Expression));

            if (keyExpression == null && Editable.Enabled)
                throw new MobinException($"Editable enabled gird must have a key which specifys edit or delet row or record");

            if (keyExpression != null)
                fetchFields.Add(keyExpression.MakeItAsSimpleExpession());

            foreach (var col in Columns)
            {
                var expression = (Expression)col.GetPropertyValue("Expression",false);
                if (expression != null)
                    fetchFields.Add(expression);
            }
            var lambdaExpression = fetchFields.GetLambdaExpression<T>();
            Guid? key = DataSource.WidgetId;
            ExpressionSaver.SerialExpressionAsJson<T>(lambdaExpression, filePath_Name, ref key, typeof(T).Assembly);
            DataSource.WidgetId = key.Value;
        }
    }
}