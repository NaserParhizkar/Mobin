using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI EditorFileBrowserSchemaModelFieldsSettings class
    /// </summary>
    public partial class EditorFileBrowserSchemaModelFieldsSettings
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
