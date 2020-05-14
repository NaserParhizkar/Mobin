using System;
using System.Linq.Expressions;

namespace Kendo.Mvc.UI.Fluent
{
    public partial class WidgetFactory<TModel>
    {
        /// <summary>
        /// Creates a new <see cref="GridSearchFromDatePickerFor{TValue}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().GridSearchFromDatePickerFor(m=>m.Property))
        /// </code>
        /// </example>
        public virtual GridSearchDatePickerBuilder GridSearchFromDatePickerFor(Expression<Func<TModel, DateTime?>> expression, string gridName)
        {
            var explorer = GetModelExplorer(expression);

            var widget = (GridSearchDatePickerBuilder)GridSearchFromDatePicker(gridName)
                    .Expression(GetExpressionName(expression));

            return widget;
        }

        /// <summary>
        /// Creates a new <see cref="GridSearchToDatePickerFor{TValue}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().GridSearchToDatePickerFor(m=>m.Property))
        /// </code>
        /// </example>
        public virtual GridSearchDatePickerBuilder GridSearchToDatePickerFor(Expression<Func<TModel, DateTime?>> expression, string gridName)
        {
            var explorer = GetModelExplorer(expression);

            var widget = (GridSearchDatePickerBuilder)GridSearchToDatePicker(gridName)
                    .Expression(GetExpressionName(expression));

            return widget;
        }
    }
}