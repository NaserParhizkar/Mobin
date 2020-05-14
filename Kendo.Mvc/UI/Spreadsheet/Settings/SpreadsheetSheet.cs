using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI SpreadsheetSheet class
    /// </summary>
    public partial class SpreadsheetSheet
    {
        public DataSource DataSource
        {
            get;
            set;
        }

        public SpreadsheetSheet()
        {
        }

        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            if (DataSource != null)
            {
                settings["dataSource"] = DataSource.ToJson();
            }

            return settings;
        }
    }
}
