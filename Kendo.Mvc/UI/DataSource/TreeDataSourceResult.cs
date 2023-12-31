﻿using Kendo.Mvc.Infrastructure;
using System.Collections;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    public class TreeDataSourceResult
    {
        public TreeDataSourceResult()
        {
            AggregateResults = new Dictionary<string, IEnumerable<AggregateResult>>();
        }

        public IEnumerable Data { get; set; }
        public IDictionary<string, IEnumerable<AggregateResult>> AggregateResults { get; set; }
        public object Errors { get; set; }
    }
}
