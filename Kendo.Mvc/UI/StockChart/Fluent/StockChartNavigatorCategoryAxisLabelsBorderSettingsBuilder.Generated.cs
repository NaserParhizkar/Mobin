using System;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring StockChartNavigatorCategoryAxisLabelsBorderSettings
    /// </summary>
    public partial class StockChartNavigatorCategoryAxisLabelsBorderSettingsBuilder<T>
        where T : class 
    {
        /// <summary>
        /// The color of the border. Accepts a valid CSS color string, including hex and rgb.
        /// </summary>
        /// <param name="value">The value for Color</param>
        public StockChartNavigatorCategoryAxisLabelsBorderSettingsBuilder<T> Color(string value)
        {
            Container.Color = value;
            return this;
        }

        /// <summary>
        /// The dash type of the border.The following dash types are supported:
        /// </summary>
        /// <param name="value">The value for DashType</param>
        public StockChartNavigatorCategoryAxisLabelsBorderSettingsBuilder<T> DashType(ChartDashType value)
        {
            Container.DashType = value;
            return this;
        }

        /// <summary>
        /// The width of the border in pixels. By default the border width is set to zero which means that the border will not appear.
        /// </summary>
        /// <param name="value">The value for Width</param>
        public StockChartNavigatorCategoryAxisLabelsBorderSettingsBuilder<T> Width(double value)
        {
            Container.Width = value;
            return this;
        }

    }
}
