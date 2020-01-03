using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI SpreadsheetSheetRowCellBorderBottomSettings class
    /// </summary>
    public partial class SpreadsheetSheetRowCellBorderBottomSettings
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
