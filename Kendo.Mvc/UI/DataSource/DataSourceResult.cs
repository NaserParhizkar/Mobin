using Kendo.Mvc.Infrastructure;
using System.Collections;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    public class DataSourceResult
    {
        public IEnumerable Data { get; set; }
        public int Total { get; set; }
        public IEnumerable<AggregateResult> AggregateResults { get; set; }
        public object Errors { get; set; }
    }
}
