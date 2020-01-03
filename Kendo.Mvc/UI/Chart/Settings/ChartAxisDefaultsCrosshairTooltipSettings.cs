using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI ChartAxisDefaultsCrosshairTooltipSettings class
    /// </summary>
    public partial class ChartAxisDefaultsCrosshairTooltipSettings<T> where T : class
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
