using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI LinearGaugeScaleMajorTicksSettings class
    /// </summary>
    public partial class LinearGaugeScaleMajorTicksSettings
    {
        /// <summary>
        /// Gets or sets the ticks dash type.
        /// </summary>
        public ChartDashType? DashType
        {
            get;
            set;
        }

        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            if (DashType.HasValue)
            {
                settings["dashType"] = DashType?.Serialize();
            }

            return settings;
        }
    }
}
