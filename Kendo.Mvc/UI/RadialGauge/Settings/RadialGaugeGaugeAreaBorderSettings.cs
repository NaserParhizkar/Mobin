using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI RadialGaugeGaugeAreaBorderSettings class
    /// </summary>
    public partial class RadialGaugeGaugeAreaBorderSettings
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
