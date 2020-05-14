using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI RadialGaugeScaleLabelsMarginSettings class
    /// </summary>
    public partial class RadialGaugeScaleLabelsMarginSettings : ISpacing
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
