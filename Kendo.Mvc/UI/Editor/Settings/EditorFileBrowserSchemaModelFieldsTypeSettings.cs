using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI EditorFileBrowserSchemaModelFieldsTypeSettings class
    /// </summary>
    public partial class EditorFileBrowserSchemaModelFieldsTypeSettings
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
