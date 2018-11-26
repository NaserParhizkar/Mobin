using System;
using System.Collections.Generic;
using System.Text;

namespace Kendo.Mvc.Mobin
{
    internal static class ComponentExpressionPath
    {
        public static IDictionary<Guid, string> ExpressionPath { get; set; } = new Dictionary<Guid, string>();
    }
}
