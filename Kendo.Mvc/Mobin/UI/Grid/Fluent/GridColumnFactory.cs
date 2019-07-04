namespace Kendo.Mvc.UI.Fluent
{
    using System;
    using System.Linq.Expressions;
    using System.Net;
    using Microsoft.AspNetCore.Mvc.Rendering;


    /// <summary>
    /// Defines the fluent interface for configuring bound columns
    /// </summary>
    /// <typeparam name="T">The type of the data item</typeparam>
    public partial class GridBoundColumnBuilder<T> : GridColumnBuilderBase<IGridBoundColumn, GridBoundColumnBuilder<T>>
        where T : class
    {
        /// <summary>
        /// Convert georjian date time to persian date time (pDate javascript type).
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// 

        /// <summary>
        /// Convert georjian date time to persian date time (pDate javascript type).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Grid(Model)
        ///             .Name("Grid")
        ///             .Columns(columns => columns.Bound(o => o.OrderDate).ConvertToPersianpDate()
        /// %&gt;
        /// </code>
        /// </example>        
        public GridBoundColumnBuilder<T> ConvertToPersianpDate(Expression<Func<T, DateTime?>> expression)
        {
            // Doing the UrlDecode to allow {0} in ActionLink e.g. Html.ActionLink("Index", "Home", new { id = "{0}" })
            return this;
        }
    }
}