using Kendo.Mvc.Extensions;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI EditorPdfSettings class
    /// </summary>
    public partial class EditorPdfSettings : PdfSettings
    {
        public override Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            settings.Merge(base.Serialize());

            return settings;
        }
    }
}
