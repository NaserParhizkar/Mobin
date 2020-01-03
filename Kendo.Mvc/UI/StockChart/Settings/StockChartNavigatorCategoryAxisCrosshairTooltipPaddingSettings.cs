using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI StockChartNavigatorCategoryAxisCrosshairTooltipPaddingSettings class
    /// </summary>
    public partial class StockChartNavigatorCategoryAxisCrosshairTooltipPaddingSettings<T> where T : class
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
