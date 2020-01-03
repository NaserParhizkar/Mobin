using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI EditorImageBrowserTransportReadSettings class
    /// </summary>
    public partial class EditorImageBrowserTransportReadSettings
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
