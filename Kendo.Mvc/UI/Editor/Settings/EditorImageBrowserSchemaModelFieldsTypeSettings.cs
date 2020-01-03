using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI EditorImageBrowserSchemaModelFieldsTypeSettings class
    /// </summary>
    public partial class EditorImageBrowserSchemaModelFieldsTypeSettings
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
