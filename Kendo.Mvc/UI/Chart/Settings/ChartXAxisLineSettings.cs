using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI ChartXAxisLineSettings class
    /// </summary>
    public partial class ChartXAxisLineSettings<T> where T : class
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
