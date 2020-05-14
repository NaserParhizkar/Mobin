using System;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI SliderTooltipSettings class
    /// </summary>
    public partial class SliderTooltipSettings<T> where T : struct, IComparable
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
