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
        public string BindedPropertyName { get; set; }

        protected override Dictionary<string, object> SerializeSettings()
        {
            var settings = base.SerializeSettings();

            if (GridName.HasValue())
            {
                settings["gridname"] = GridName;
            }

            if (BindedPropertyName.HasValue())
            {
                settings["bindedpropertyname"] = BindedPropertyName;
            }

            if (Placeholder.HasValue())
            {
                settings["placeholder"] = Placeholder;
            }

            return settings;
        }
    }
}
