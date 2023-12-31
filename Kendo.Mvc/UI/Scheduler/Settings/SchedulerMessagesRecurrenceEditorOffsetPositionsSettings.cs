using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI SchedulerMessagesRecurrenceEditorOffsetPositionsSettings class
    /// </summary>
    public partial class SchedulerMessagesRecurrenceEditorOffsetPositionsSettings<T> where T : class, ISchedulerEvent
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
