using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI ChartLegendLabelsSettings class
    /// </summary>
    public partial class ChartLegendLabelsSettings<T> where T : class
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
