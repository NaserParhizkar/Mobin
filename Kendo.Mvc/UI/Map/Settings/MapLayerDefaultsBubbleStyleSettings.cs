using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI MapLayerDefaultsBubbleStyleSettings class
    /// </summary>
    public partial class MapLayerDefaultsBubbleStyleSettings
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
