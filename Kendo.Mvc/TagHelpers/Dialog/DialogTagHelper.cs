using Kendo.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace Kendo.Mvc.TagHelpers
{
    /// <summary>
    /// Kendo UI Dialog TagHelper
    /// </summary>
    [HtmlTargetElement("kendo-dialog")]
    [OutputElementHint("div")]
    public partial class DialogTagHelper : TagHelperBase
    {
        public DialogTagHelper(IKendoHtmlGenerator generator) : base(generator)
        {
        }

        protected override void WriteHtml(TagHelperOutput output)
        {
            GenerateId(output);

            var htmlAttributes = new Dictionary<string, object>();

            if (!Visible.GetValueOrDefault(true))
            {
                htmlAttributes.Add("style", "display:none");
            }

            var tagBuilder = Generator.GenerateTag("div", ViewContext, Id, Name, htmlAttributes);

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.MergeAttributes(tagBuilder);
        }

        protected override string GetInitializationScript()
        {
            var settings = SerializeSettings();

            // TODO: Manually serialized settings go here

            return Initializer.Initialize(Selector, "Dialog", settings);
        }
    }
}

