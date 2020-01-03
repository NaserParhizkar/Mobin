using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI LinearGaugeScaleLabelsBorderSettings class
    /// </summary>
    public partial class LinearGaugeScaleLabelsBorderSettings
    {
        /// <summary>
        /// Gets or sets the label opacity.
        /// </summary>
        /// <value>
        /// The label opacity.
        /// </value>
        public double? Opacity
        {
            get;
            set;
        }

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
