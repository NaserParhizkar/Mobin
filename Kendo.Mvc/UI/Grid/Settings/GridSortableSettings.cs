using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI GridSortableSettings class
    /// </summary>
    public partial class GridSortableSettings<T>
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            if (SortMode.HasValue)
            {
                settings["mode"] = SortMode?.Serialize();
            }

            return settings;
        }
    }
}
