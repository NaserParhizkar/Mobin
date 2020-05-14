using Kendo.Mvc.Extensions;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI MapMarkerDefaultsSettings class
    /// </summary>
    public static class IMapMarkersShapeSettingsExtensions
    {
        public static void SerializeShape(this IMapMarkersShapeSettings self, Dictionary<string, object> settings)
        {
            if (self.ShapeName.HasValue())
            {
                settings["shape"] = self.ShapeName;
            }
            else if (self.Shape.HasValue)
            {
                var shapeName = self.Shape.ToString();
                settings["shape"] = shapeName.ToLowerInvariant()[0] + shapeName.Substring(1);
            }
        }
    }
}
