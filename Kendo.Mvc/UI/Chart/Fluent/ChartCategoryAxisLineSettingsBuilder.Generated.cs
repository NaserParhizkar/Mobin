using System;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring ChartCategoryAxisLineSettings
    /// </summary>
    public partial class ChartCategoryAxisLineSettingsBuilder<T>
        where T : class 
    {
        /// <summary>
        /// The color of the lines. Accepts a valid CSS color string, including hex and rgb.
        /// </summary>
        /// <param name="value">The value for Color</param>
        public ChartCategoryAxisLineSettingsBuilder<T> Color(string value)
        {
            Container.Color = value;
            return this;
        }

        /// <summary>
        /// The dash type of the line.The following dash types are supported:
        /// </summary>
        /// <param name="value">The value for DashType</param>
        public ChartCategoryAxisLineSettingsBuilder<T> DashType(ChartDashType value)
        {
            Container.DashType = value;
            return this;
        }

        /// <summary>
        /// If set to true the chart will display the category axis lines. By default the category axis lines are visible.
        /// </summary>
        /// <param name="value">The value for Visible</param>
        public ChartCategoryAxisLineSettingsBuilder<T> Visible(bool value)
        {
            Container.Visible = value;
            return this;
        }

        /// <summary>
        /// The width of the line in pixels. Also affects the major and minor ticks, but not the grid lines.
        /// </summary>
        /// <param name="value">The value for Width</param>
        public ChartCategoryAxisLineSettingsBuilder<T> Width(double value)
        {
            Container.Width = value;
            return this;
        }

    }
}
