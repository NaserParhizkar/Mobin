using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI DateInput component
    /// </summary>
    public partial class DateInput : WidgetBase

    {
        public DateInput(ViewContext viewContext) : base(viewContext)
        {
        }

        protected override void WriteHtml(TextWriter writer)
        {
            var tag = Generator.GenerateTag("input", ViewContext, Id, Name, HtmlAttributes);

            tag.WriteTo(writer, HtmlEncoder);

            base.WriteHtml(writer);
        }

        public override void WriteInitializationScript(TextWriter writer)
        {
            var settings = SerializeSettings();

            // TODO: Manually serialized settings go here

            writer.Write(Initializer.Initialize(Selector, "DateInput", settings));
        }
    }
}

