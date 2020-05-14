using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI MapMarkerDefaultsSettings class
    /// </summary>
    public partial class MapMarkerDefaultsSettings : MapBaseLayerSettings, IMapMarkersShapeSettings
    {
        public string ShapeName { get; set; }

        protected override ViewContext ViewContext
        {
            get
            {
                return Map?.ViewContext;
            }
        }

        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            SerializeTooltip(settings);
            this.SerializeShape(settings);

            return settings;
        }
    }
}
