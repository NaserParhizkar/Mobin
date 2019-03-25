using System;
using System.Collections.Generic;
using System.Text;

namespace Kendo.Mvc.UI.Fluent
{
    public partial class WidgetFactory<TModel>
    {
        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Grid{T}"/> bound to the specified data item type.
        /// </summary>
        /// <example>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <code lang="CS">
        ///  @(Html.Kendo().Grid&lt;Order&gt;()
        ///             .Name("Grid")
        ///             .BindTo(Model)
        /// )
        /// </code>
        /// </example>      
        public virtual GridBuilder<T> MobinGrid<T>() where T : class
        {
            return new GridBuilder<T>(new Grid<T>(HtmlHelper.ViewContext));
        }
    }
}