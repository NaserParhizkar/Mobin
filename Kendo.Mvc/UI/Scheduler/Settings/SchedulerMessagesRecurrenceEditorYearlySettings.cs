using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI SchedulerMessagesRecurrenceEditorYearlySettings class
    /// </summary>
    public partial class SchedulerMessagesRecurrenceEditorYearlySettings<T> where T : class, ISchedulerEvent
    {
        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            // Do manual serialization here

            return settings;
        }
    }
}
