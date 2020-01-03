using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI LinearGaugeScaleLabelsMarginSettings class
    /// </summary>
    public partial class LinearGaugeScaleLabelsMarginSettings : ISpacing
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
