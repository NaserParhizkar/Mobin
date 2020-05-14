using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI DropDownList component
    /// </summary>
    public partial class GridSearchDropDownList : DropDownList
    {
        public string GridName { get; set; }

        protected override Dictionary<string, object> SerializeSettings()
        {
            var settings = base.SerializeSettings();

            if (GridName?.HasValue() == true)
            {
                settings["gridname"] = GridName;
            }

            return settings;
        }
    }
}
