using System;
using System.Linq.Expressions;

namespace Kendo.Mvc.UI.Fluent
{
    public partial class WidgetFactory<TModel>
    {
        /// <summary>
        /// Creates a new <see cref="GridSearchInput{TValue}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().GridSearchInputFor(m=>m.Property))
        /// </code>
        /// </example>
        public virtual GridSearchInputBuilder GridSearchInputFor(Expression<Func<TModel, string>> expression, string gridName)
        {
            var explorer = GetModelExplorer(expression);

            var widget = GridSearchInput(gridName)
                    .Expression(GetExpressionName(expression))
                    .Format(ExtractEditFormat(explorer.Metadata.EditFormatString))
                    .Value((string)explorer.Model);

            return widget;
        }
    }
}