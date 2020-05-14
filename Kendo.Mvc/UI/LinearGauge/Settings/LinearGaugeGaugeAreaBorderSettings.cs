using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI LinearGaugeGaugeAreaBorderSettings class
    /// </summary>
    public partial class LinearGaugeGaugeAreaBorderSettings
    {
        public double? Opacity { get; set; }

        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            if (Opacity.HasValue)
            {
                settings["opacity"] = Opacity;
            }

            return settings;
        }
    }
}
