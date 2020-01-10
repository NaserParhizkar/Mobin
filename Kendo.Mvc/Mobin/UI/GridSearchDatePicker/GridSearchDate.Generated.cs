using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI GridSearchFromDatePicker component
    /// </summary>
    public abstract partial class GridSearchDatePicker : DatePicker
    {
        public string Placeholder { get; set; }

        public string GridName { get; set; }

        protected override Dictionary<string, object> SerializeSettings()
        {
            var settings = base.SerializeSettings();

            if (GridName?.HasValue() == true)
            {
                settings["gridname"] = GridName;
            }

            if (Placeholder?.HasValue() == true)
            {
                settings["placeholder"] = Placeholder;
            }

            return settings;
        }
    }
}
