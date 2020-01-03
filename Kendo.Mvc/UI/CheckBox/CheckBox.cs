using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI CheckBox component
    /// </summary>
    public partial class CheckBox : WidgetBase

    {
        public CheckBox(ViewContext viewContext) : base(viewContext)
        {
            Enabled = true;
        }

        public override void WriteInitializationScript(TextWriter writer) { }

        protected override void WriteHtml(TextWriter writer)
        {
            VerifySettings();

            var builder = GetHtmlBuilder();

            builder.WriteHtml(writer, HtmlEncoder);
        }

        protected virtual CheckBoxHtmlBuilder GetHtmlBuilder()
        {
            return new CheckBoxHtmlBuilder(this);
        }
    }
}