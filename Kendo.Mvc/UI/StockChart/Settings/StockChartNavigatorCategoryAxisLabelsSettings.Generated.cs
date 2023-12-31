using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI StockChartNavigatorCategoryAxisLabelsSettings class
    /// </summary>
    public partial class StockChartNavigatorCategoryAxisLabelsSettings<T> where T : class 
    {
        public string Background { get; set; }

        public StockChartNavigatorCategoryAxisLabelsBorderSettings<T> Border { get; } = new StockChartNavigatorCategoryAxisLabelsBorderSettings<T>();

        public string Color { get; set; }

        public string Culture { get; set; }

        public StockChartNavigatorCategoryAxisLabelsDateFormatsSettings<T> DateFormats { get; } = new StockChartNavigatorCategoryAxisLabelsDateFormatsSettings<T>();

        public string Font { get; set; }

        public string Format { get; set; }

        public StockChartNavigatorCategoryAxisLabelsMarginSettings<T> Margin { get; } = new StockChartNavigatorCategoryAxisLabelsMarginSettings<T>();

        public bool? Mirror { get; set; }

        public StockChartNavigatorCategoryAxisLabelsPaddingSettings<T> Padding { get; } = new StockChartNavigatorCategoryAxisLabelsPaddingSettings<T>();

        public double? Rotation { get; set; }

        public double? Skip { get; set; }

        public double? Step { get; set; }

        public string Template { get; set; }

        public string TemplateId { get; set; }

        public bool? Visible { get; set; }


        public StockChart<T> StockChart { get; set; }

        protected Dictionary<string, object> SerializeSettings()
        {
            var settings = new Dictionary<string, object>();

            if (Background?.HasValue() == true)
            {
                settings["background"] = Background;
            }

            var border = Border.Serialize();
            if (border.Any())
            {
                settings["border"] = border;
            }

            if (Color?.HasValue() == true)
            {
                settings["color"] = Color;
            }

            if (Culture?.HasValue() == true)
            {
                settings["culture"] = Culture;
            }

            var dateFormats = DateFormats.Serialize();
            if (dateFormats.Any())
            {
                settings["dateFormats"] = dateFormats;
            }

            if (Font?.HasValue() == true)
            {
                settings["font"] = Font;
            }

            if (Format?.HasValue() == true)
            {
                settings["format"] = Format;
            }

            var margin = Margin.Serialize();
            if (margin.Any())
            {
                settings["margin"] = margin;
            }

            if (Mirror.HasValue)
            {
                settings["mirror"] = Mirror;
            }

            var padding = Padding.Serialize();
            if (padding.Any())
            {
                settings["padding"] = padding;
            }

            if (Rotation.HasValue)
            {
                settings["rotation"] = Rotation;
            }

            if (Skip.HasValue)
            {
                settings["skip"] = Skip;
            }

            if (Step.HasValue)
            {
                settings["step"] = Step;
            }

            if (TemplateId.HasValue())
            {
                settings["template"] = new ClientHandlerDescriptor {
                    HandlerName = string.Format(
                        "jQuery('{0}{1}').html()", StockChart.IdPrefix, TemplateId
                    )
                };
            }
            else if (Template.HasValue())
            {
                settings["template"] = Template;
            }

            if (Visible.HasValue)
            {
                settings["visible"] = Visible;
            }

            return settings;
        }
    }
}
