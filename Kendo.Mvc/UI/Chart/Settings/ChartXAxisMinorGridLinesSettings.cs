using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI ChartXAxisMinorGridLinesSettings class
    /// </summary>
    public partial class ChartXAxisMinorGridLinesSettings<T> where T : class
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
