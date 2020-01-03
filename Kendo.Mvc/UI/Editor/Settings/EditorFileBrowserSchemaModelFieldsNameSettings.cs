using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI EditorFileBrowserSchemaModelFieldsNameSettings class
    /// </summary>
    public partial class EditorFileBrowserSchemaModelFieldsNameSettings
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
