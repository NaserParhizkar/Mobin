using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI LinearGaugeGaugeAreaMarginSettings class
    /// </summary>
    public partial class LinearGaugeGaugeAreaMarginSettings 
    {
        public double? Top { get; set; }

        public double? Bottom { get; set; }

        public double? Left { get; set; }

        public double? Right { get; set; }


        public LinearGauge LinearGauge { get; set; }

        protected Dictionary<string, object> SerializeSettings()
        {
            var settings = new Dictionary<string, object>();

            if (Top.HasValue)
            {
                settings["top"] = Top;
            }

            if (Bottom.HasValue)
            {
                settings["bottom"] = Bottom;
            }

            if (Left.HasValue)
            {
                settings["left"] = Left;
            }

            if (Right.HasValue)
            {
                settings["right"] = Right;
            }

            return settings;
        }
    }
}
