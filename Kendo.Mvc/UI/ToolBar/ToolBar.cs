using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI ToolBar component
    /// </summary>
    public partial class ToolBar : WidgetBase

    {
        public ToolBar(ViewContext viewContext) : base(viewContext)
        {
        }

        protected override void WriteHtml(TextWriter writer)
        {
            var tag = Generator.GenerateTag("div", ViewContext, Id, Name, HtmlAttributes);

            tag.WriteTo(writer, HtmlEncoder);

            base.WriteHtml(writer);
        }

        public override void WriteInitializationScript(TextWriter writer)
        {
            var settings = SerializeSettings();

            writer.Write(Initializer.Initialize(Selector, "ToolBar", settings));
        }
    }
}

