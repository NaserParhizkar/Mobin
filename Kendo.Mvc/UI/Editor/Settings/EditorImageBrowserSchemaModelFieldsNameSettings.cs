using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI EditorImageBrowserSchemaModelFieldsNameSettings class
    /// </summary>
    public partial class EditorImageBrowserSchemaModelFieldsNameSettings
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
