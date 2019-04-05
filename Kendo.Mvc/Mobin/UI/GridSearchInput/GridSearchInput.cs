using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Mobin.Common;
using System.IO;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI GridSearchInput component
    /// </summary>
    public partial class GridSearchInput : WidgetBase
    {
        public GridSearchInput(ViewContext viewContext,string gridName) : base(viewContext)
        {
            if (!gridName.HasValue())
                throw new MobinException($"GridName must be specify for GridSearchInput Component");

            GridName = gridName;
        }

        protected override void WriteHtml(TextWriter writer)
        {
            // Do custom rendering here

            var explorer = ExpressionMetadataProvider.FromStringExpression(Name, HtmlHelper.ViewData, HtmlHelper.MetadataProvider);
            var tag = Generator.GenerateGridSearchInput(ViewContext, explorer, Id, Name, Value, string.Empty, HtmlAttributes);

            if (Value != null)
            {
                tag.MergeAttribute("value", "{0}".FormatWith(Value));
            }

            tag.TagRenderMode = TagRenderMode.SelfClosing;
            tag.WriteTo(writer, HtmlEncoder);

            base.WriteHtml(writer);
        }

        public override void WriteInitializationScript(TextWriter writer)
        {
            var settings = SerializeSettings();

            // TODO: Manually serialized settings go here			

            writer.Write(Initializer.Initialize(Selector, "GridSearchInput", settings));
        }
    }
}

