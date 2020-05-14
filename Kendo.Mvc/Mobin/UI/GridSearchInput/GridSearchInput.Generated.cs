using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI GridSearchInput component
    /// </summary>
    public partial class GridSearchInput
    {
        public string Culture { get; set; }

        public string Format { get; set; }

        public string Placeholder { get; set; }

        public string Value { get; set; }

        public string GridName { get; set; }

        protected override Dictionary<string, object> SerializeSettings()
        {
            var settings = base.SerializeSettings();

            if (GridName?.HasValue() == true)
            {
                settings["gridname"] = GridName;
            }

            if (Culture?.HasValue() == true)
            {
                settings["culture"] = Culture;
            }

            if (Format?.HasValue() == true)
            {
                settings["format"] = Format;
            }

            if (Placeholder?.HasValue() == true)
            {
                settings["placeholder"] = Placeholder;
            }

            return settings;
        }
    }
}
