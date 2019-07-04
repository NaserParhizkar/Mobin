using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kendo.Mvc.UI.Fluent
{
    public partial class WidgetFactory<TModel>
    {
        /// <summary>
        /// Creates a new <see cref="DropDownList"/> bound to a model field.
        /// If you specify datatextfield and datavaluefield in specified method they don't have any effects
        /// and it's specified by this second and third parameter's 
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// @Html.Kendo().DropDownListFor(m => m.Property)
        /// </code>
        /// </example>
        public virtual DropDownListBuilder MobinDropDownListFor<TEntityModel, TValue>(Expression<Func<TModel, TValue>> expression,
            Expression<Func<TEntityModel,dynamic>> valueFieldExp, Expression<Func<TEntityModel,dynamic>> textFieldExp)
        {
            var expressionName = ExpressionHelper.GetExpressionText(expression);
            var widget = DropDownList()
                    .Expression(expressionName);

            widget.Container.DataFields = new Dictionary<string, Expression>
                {
                    { nameof(widget.Container.DataTextField),textFieldExp},
                    { nameof(widget.Container.DataValueField),valueFieldExp}
                };

            return widget;
        }
    }
}