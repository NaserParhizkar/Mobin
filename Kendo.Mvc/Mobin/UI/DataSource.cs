using System;
using System.Collections.Generic;
using System.Text;

namespace Kendo.Mvc.UI
{
    public class MobinDataSource : DataSource
    {
        public Guid? ComponentId { get; set; }



        protected virtual void MobinSettings(DataSourceRequest dataSourceRequest)
        {
            dataSourceRequest.ComponentId = ComponentId;
        }

        protected override void SerializeMobinChanges(IDictionary<string, object> json)
        {
            if (ComponentId.HasValue && ComponentId.Value != Guid.Empty)
            {
                json["componentId"] = ComponentId;
            }
        }
    }
}
