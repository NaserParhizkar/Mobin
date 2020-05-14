using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI NotificationPositionSettings class
    /// </summary>
    public partial class NotificationPositionSettings
    {
        public NotificationPositionSettings()
        {
            Pinned = true;
        }

        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            return settings;
        }
    }
}
