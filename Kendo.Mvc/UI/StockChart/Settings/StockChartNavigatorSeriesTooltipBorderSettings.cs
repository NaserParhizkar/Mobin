using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI StockChartNavigatorSeriesTooltipBorderSettings class
    /// </summary>
    public partial class StockChartNavigatorSeriesTooltipBorderSettings<T> where T : class
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
