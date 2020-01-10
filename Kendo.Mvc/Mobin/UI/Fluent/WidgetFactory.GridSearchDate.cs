namespace Kendo.Mvc.UI.Fluent
{
    public partial class WidgetFactory<TModel>
    {
        /// <summary>
        /// Creates a new <see cref="GridSearchFromDatePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///	 @(Html.Kendo().GridSearchDatePicker()
        ///		.Name("GridSearchDatePicker")
        ///	 )
        /// </code>
        /// </example>
        public virtual GridSearchDatePickerBuilder GridSearchFromDatePicker(string gridName)
        {
            return new GridSearchFromDatePickerBuilder(new GridSearchFromDatePicker(HtmlHelper.ViewContext, gridName));
        }

        /// <summary>
        /// Creates a new <see cref="GridSearchToDatePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///	 @(Html.Kendo().GridSearchToDatePicker()
        ///		.Name("GridSearchToDatePicker")
        ///	 )
        /// </code>
        /// </example>
        public virtual GridSearchDatePickerBuilder GridSearchToDatePicker(string gridName)
        {
            return new GridSearchToDatePickerBuilder(new GridSearchToDatePicker(HtmlHelper.ViewContext, gridName));
        }
    }
}