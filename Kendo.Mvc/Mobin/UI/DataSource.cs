using System;
using System.Collections.Generic;
using System.Text;

namespace Kendo.Mvc.UI
{
    public partial class DataSource 
    {
        public Guid? ComponentId { get; set; }

        protected virtual void MobinSettings(DataSourceRequest dataSourceRequest)
        {
            dataSourceRequest.ComponentId = ComponentId;
        }

        protected override void SerializeMobin(IDictionary<string, object> json)
        {
            if (ComponentId.HasValue && ComponentId.Value != Guid.Empty)
            {
                json["componentId"] = ComponentId;
            }
        }
    }
}
