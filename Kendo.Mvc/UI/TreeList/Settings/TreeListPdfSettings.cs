using Kendo.Mvc.Extensions;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI TreeListPdfSettings class
    /// </summary>
    public partial class TreeListPdfSettings<T> : PdfSettings
    {
        public override Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            settings.Merge(base.Serialize());

            return settings;
        }
    }
}
