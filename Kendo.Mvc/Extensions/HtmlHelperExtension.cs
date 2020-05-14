using Kendo.Mvc.UI.Fluent;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kendo.Mvc.UI
{
    public static class HtmlHelperExtension
    {
        public static WidgetFactory<TModel> Kendo<TModel>(this IHtmlHelper<TModel> helper)
        {
            return new WidgetFactory<TModel>(helper);
        }
    }
}