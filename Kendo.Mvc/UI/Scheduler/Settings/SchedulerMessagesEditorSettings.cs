using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI SchedulerMessagesEditorSettings class
    /// </summary>
    public partial class SchedulerMessagesEditorSettings<T> where T : class, ISchedulerEvent
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
