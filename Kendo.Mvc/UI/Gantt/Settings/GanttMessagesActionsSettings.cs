using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI GanttMessagesActionsSettings class
    /// </summary>
    public partial class GanttMessagesActionsSettings<TTaskModel, TDependenciesModel> where TTaskModel : class, IGanttTask where TDependenciesModel : class, IGanttDependency
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
