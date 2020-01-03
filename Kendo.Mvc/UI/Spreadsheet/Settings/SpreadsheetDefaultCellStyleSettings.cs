using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI SpreadsheetDefaultCellStyleSettings class
    /// </summary>
    public partial class SpreadsheetDefaultCellStyleSettings
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
