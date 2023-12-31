using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI ProgressBarAnimationSettings class
    /// </summary>
    public partial class ProgressBarAnimationSettings
    {
        public bool Enable { get; set; } = true;

        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            if (!Enable)
            {
                settings["animation"] = false;
            }

            return settings;
        }
    }
}
