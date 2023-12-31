using Kendo.Mvc.Extensions;
using Kendo.Mvc.Rendering;
using Kendo.Mvc.Resources;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;

namespace Kendo.Mvc.TagHelpers
{
    /// <summary>
    /// Kendo UI DatePicker TagHelper
    /// </summary>
    [HtmlTargetElement("kendo-datepicker")]
    [OutputElementHint("input")]
    public partial class DatePickerTagHelper : TagHelperBase
    {
        /// <summary>
        /// An expression to be evaluated against the current model.
        /// </summary>
        public ModelExpression For { get; set; }

        /// <summary>
        /// MonthTemplateId to be used for rendering the cells of the Calendar.
        /// </summary>
        public string MonthTemplateId { get; set; }

        /// <summary>
        /// Templates for the cells rendered in the "month" view.
        /// </summary>
        public string MonthTemplate { get; set; }

        public DatePickerTagHelper(IKendoHtmlGenerator generator) : base(generator)
        {
        }

        protected override void WriteHtml(TagHelperOutput output)
        {
            ModelMetadata metadata = null;
            ModelExplorer explorer = null;

            if (For != null)
            {
                explorer = For.ModelExplorer;
                metadata = For.Metadata;
                Name = For.Name;

                Value = Value ?? For.Model as DateTime?;

                Format = ExtractEditFormat(For.ModelExplorer.Metadata.EditFormatString);

                Min = Min ?? GetRangeValidationParameter<DateTime>(explorer, MinimumValidator);
                Max = Max ?? GetRangeValidationParameter<DateTime>(explorer, MaximumValidator);
            }

            GenerateId(output);

            var htmlAttributes = new Dictionary<string, object>();

            var tagBuilder = Generator.GenerateDateInput(ViewContext, explorer,
                Id, Name, Value, Format, htmlAttributes);

            output.TagName = "input";
            output.TagMode = TagMode.SelfClosing;

            output.MergeAttributes(tagBuilder);
        }

        protected override string GetInitializationScript()
        {
            var settings = SerializeSettings();

            if (MonthTemplateId?.HasValue() == true)
            {
                settings["month"] = new
                {
                    content = new ClientHandlerDescriptor
                    {
                        HandlerName = string.Format("jQuery('{0}{1}').html()", IdPrefix, MonthTemplateId)
                    }
                };
            }
            else if (MonthTemplate?.HasValue() == true)
            {
                settings["month"] = new { content = MonthTemplate };
            }

            return Initializer.Initialize(Selector, "DatePicker", settings);
        }

        protected override void VerifySettings()
        {
            base.VerifySettings();

            if (Min > Max)
            {
                throw new ArgumentException(Exceptions.MinPropertyMustBeLessThenMaxProperty.FormatWith("Min", "Max"));
            }
        }
    }
}

