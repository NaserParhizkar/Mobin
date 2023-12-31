using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI ChartValueAxisCrosshairSettings class
    /// </summary>
    public partial class ChartValueAxisCrosshairSettings<T> where T : class 
    {
        public string Color { get; set; }

        public double? Opacity { get; set; }

        public ChartValueAxisCrosshairTooltipSettings<T> Tooltip { get; } = new ChartValueAxisCrosshairTooltipSettings<T>();

        public bool? Visible { get; set; }

        public double? Width { get; set; }


        public Chart<T> Chart { get; set; }

        protected Dictionary<string, object> SerializeSettings()
        {
            var settings = new Dictionary<string, object>();

            if (Color?.HasValue() == true)
            {
                settings["color"] = Color;
            }

            if (Opacity.HasValue)
            {
                settings["opacity"] = Opacity;
            }

            var tooltip = Tooltip.Serialize();
            if (tooltip.Any())
            {
                settings["tooltip"] = tooltip;
            }

            if (Visible.HasValue)
            {
                settings["visible"] = Visible;
            }

            if (Width.HasValue)
            {
                settings["width"] = Width;
            }

            return settings;
        }
    }
}
