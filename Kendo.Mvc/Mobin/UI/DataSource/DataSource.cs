using System;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    public partial class DataSource
    {
        internal Guid WidgetId { get; set; }
        internal bool AutoMakeQueryExpression { get; set; }

        protected virtual void MobinSettings(DataSourceRequest dataSourceRequest)
        {
            dataSourceRequest.WidgetId = WidgetId;
            dataSourceRequest.AutoMakeQueryExpression = AutoMakeQueryExpression;
        }

        protected override void SerializeMobinChanges(IDictionary<string, object> json)
        {
            if (WidgetId != Guid.Empty)
                json["widgetId"] = WidgetId;

            if (AutoMakeQueryExpression)
                json["autoMakeQueryExpression"] = AutoMakeQueryExpression;
        }
    }
}
