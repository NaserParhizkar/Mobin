namespace Kendo.Mvc.UI.Fluent
{
    public partial class WidgetFactory<TModel>
    {
        /// <summary>
        /// Creates a new <see cref="GridSearchDropDownList"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().GridSearchDropDownList()
        ///             .Name("GridSearchDropDownList")
        ///             .Items(items =>
        ///             {
        ///                 items.Add().Text("First Item");
        ///                 items.Add().Text("Second Item");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual GridSearchDropDownListBuilder GridSearchDropDownList(string gridName)
        {
            return new GridSearchDropDownListBuilder(new GridSearchDropDownList(HtmlHelper.ViewContext, gridName));
        }
    }
}