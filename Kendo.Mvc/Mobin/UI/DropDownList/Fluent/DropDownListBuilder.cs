using Mobin.Common;
using Mobin.Common.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring the Kendo UI DropDownList
    /// </summary>
    public partial class DropDownListBuilder
    {
        /// <summary>
        /// This function used for auto fetch data and value fields which is shown in dropdownlist from database
        /// </summary>
        /// <param name="function">functions for fetch data and value text field</param>
        public DropDownListBuilder AutoFetchValueTextFields<TModel>(Func<ValueTextFieldBuilder<TModel>, ValueTextFieldBuilder<TModel>> function)
        {
            var valueTextFieldInstance = new ValueTextFieldBuilder<TModel>();
            var value_text_expression = function(valueTextFieldInstance);
            if (value_text_expression.value_text_field == null)
                throw new MobinException($"You must specify DataTextField and DataValueField");

            Component.DataFields = value_text_expression.value_text_field;
            var valueExpression = Component.DataFields[nameof(DropDownList.DataValueField)];
            var textExpression = Component.DataFields[nameof(DropDownList.DataTextField)];
            Component.DataValueField = ExpressionHelper.GetExpressionText((LambdaExpression)valueExpression);
            Component.DataTextField = ExpressionHelper.GetExpressionText((LambdaExpression)textExpression);

            return this;
        }

        public class ValueTextFieldBuilder<TModel>
        {
            internal IDictionary<string, Expression> value_text_field = new Dictionary<string, Expression>();

            /// <summary>
            /// This Expression used for auto fetch data and value fields which is shown in dropdownlist
            /// </summary>
            /// <param name="valueFieldExpression">call this function in order to fetch data Text field</param>
            public ValueTextFieldBuilder<TModel> DataValueField<TValue>(System.Linq.Expressions.Expression<Func<TModel, TValue>> valueFieldExpression)
            {
                var valueFieldName = nameof(DropDownList.DataValueField);
                if (!value_text_field.Keys.Contains(valueFieldName))
                    value_text_field.Add(valueFieldName, valueFieldExpression);
                return this;
            }

            /// <summary>
            /// This Expression used for auto fetch data and value fields which is shown in dropdownlist
            /// </summary>
            /// <param name="textFieldExpression">call this function in order to fetch data Value field</param>
            public ValueTextFieldBuilder<TModel> DataTextField<TValue>(System.Linq.Expressions.Expression<Func<TModel, TValue>> textFieldExpression)
            {
                var textFieldName = nameof(DropDownList.DataTextField);
                if (!value_text_field.Keys.Contains(textFieldName))
                    value_text_field.Add(textFieldName, textFieldExpression);
                return this;
            }
        }
    }
}

