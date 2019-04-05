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

        ///// <summary>
        ///// Creates a new <see cref="GridSearchInput"/>.
        ///// </summary>
        ///// <example>
        ///// <code lang="CS">
        /////  &lt;%= Html.Kendo().GridSearchInput()
        /////             .Name("GridSearchInput")
        ///// %&gt;
        ///// </code>
        ///// </example>
        //public virtual GridSearchInputBuilder<string> GridSearchInput(string gridName)
        //{
        //    return new GridSearchInputBuilder<string>(new GridSearchInput<string>(HtmlHelper.ViewContext,gridName));
        //}

        ///// <summary>
        ///// Creates a new <see cref="GridSearchInput{T}"/>.
        ///// </summary>
        ///// <example>
        ///// <code lang="CS">
        /////  &lt;%= Html.Kendo().GridSearchInput&lt;double&gt;()
        /////             .Name("GridSearchInput")
        ///// %&gt;
        ///// </code>
        ///// </example>
        //public virtual GridSearchInputBuilder<T> GridSearchInput<T>(string gridName)
        //{
        //    return new GridSearchInputBuilder<T>(new GridSearchInput<T>(HtmlHelper.ViewContext,gridName));
        //}



        ///// <summary>
        ///// Creates a new <see cref="GridSearchInput"/>.
        ///// </summary>
        ///// <example>
        ///// <code lang="CS">
        /////  &lt;%= Html.Kendo().GridSearchInputFor(m=>m.Property) %&gt;
        ///// </code>
        ///// </example>
        //public virtual GridSearchInputBuilder<TProperty> GridSearchInputFor<TProperty>
        //    (Expression<Func<TModel, TProperty>> expression, string gridName)
        //{
        //    var explorer = GetModelExplorer(expression);

        //    return GridSearchInput<TProperty>(gridName)
        //            .Expression(GetExpressionName(expression))
        //            .Value((TProperty)explorer.Model);
        //}
    }
}