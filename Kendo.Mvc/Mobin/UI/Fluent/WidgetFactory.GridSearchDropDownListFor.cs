using Kendo.Mvc.Extensions;
using System;
using System.Linq.Expressions;

namespace Kendo.Mvc.UI.Fluent
{
    public partial class WidgetFactory<TModel>
    {
        /// <summary>
        /// Creates a new <see cref="GridSearchDropDownList"/> bound to a model field.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// @Html.Kendo().GridSearchDropDownListFor(m => m.Property)
        /// </code>
        /// </example>
        public virtual GridSearchDropDownListBuilder GridSearchDropDownListFor<TValue>(Expression<Func<TModel, TValue>> expression, string gridName)
        {
            var explorer = GetModelExplorer(expression);
            var model = explorer.Model;

            var widget = (GridSearchDropDownListBuilder)GridSearchDropDownList(gridName)
                    .Expression(GetExpressionName(expression))
                    .Value(GetValueWithEnum(expression));

            return widget;
        }
    }
}