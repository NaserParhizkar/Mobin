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
    public partial class DropDownList
    {
        internal IDictionary<string,Expression> DataFields { get; set; }

        protected override void MobinProcessSettings()
        {
            if (DataSource.AutoMakeQueryExpression)
            {
                DataSource.WidgetId = Guid.NewGuid();
                SerialSelectorFieldsAsJson();
            }
            base.MobinProcessSettings();
        }

        private void SerialSelectorFieldsAsJson()
        {
            var filePath_Name = ExpressionDefaultFileAddress.GetDefaultfilePathName(Name, ViewContext);
            List<Expression> value_text_expressions = new List<Expression>();

            foreach (var expression in DataFields.Values)
            {
                if (expression != null)
                    value_text_expressions.Add(expression);
            }

            var lambdaExpression = value_text_expressions.GetLambdaExpression<string>();
            Guid? key = DataSource.WidgetId;
            ExpressionSaver.SerialExpressionAsJson<string>(lambdaExpression, filePath_Name, ref key, typeof(string).Assembly);
            DataSource.WidgetId = key.Value;
        }
    }
}