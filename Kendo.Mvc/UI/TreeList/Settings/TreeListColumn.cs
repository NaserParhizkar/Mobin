using Kendo.Mvc.Extensions;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI TreeListColumn class
    /// </summary>
    public partial class TreeListColumn<T>
    {
        public string Editor { get; set; }

        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            if (Editor.HasValue())
            {
                settings.Add("editor", Editor);
            }

            return settings;
        }
    }
}
