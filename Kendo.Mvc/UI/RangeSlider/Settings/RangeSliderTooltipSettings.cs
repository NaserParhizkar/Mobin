using System;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI RangeSliderTooltipSettings class
    /// </summary>
    public partial class RangeSliderTooltipSettings<T> where T : struct, IComparable
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
