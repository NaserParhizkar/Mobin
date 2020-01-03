using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI GanttColumn class
    /// </summary>
    public partial class GanttColumn<TTaskModel, TDependenciesModel> where TTaskModel : class, IGanttTask where TDependenciesModel : class, IGanttDependency
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
