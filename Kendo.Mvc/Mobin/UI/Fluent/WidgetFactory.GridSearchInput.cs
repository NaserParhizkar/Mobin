using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kendo.Mvc.UI.Fluent
{
    public partial class WidgetFactory<TModel>
    {
        /// <summary>
        /// Creates a new <see cref="GridSearchInput"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///	 @(Html.Kendo().GridSearchInput()
        ///		.Name("GridSearchInput")
        ///	 )
        /// </code>
        /// </example>
        public virtual GridSearchInputBuilder GridSearchInput(string gridName)
        {
            return new GridSearchInputBuilder(new GridSearchInput(HtmlHelper.ViewContext,gridName));
        }
    }
}