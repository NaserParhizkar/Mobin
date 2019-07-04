using System;
using System.Collections.Generic;
using System.Text;

namespace Mobin.ExpressionJsonSerializer
{
    public static class ExpressionPathKeeper
    {
        public static IDictionary<Guid, string> ExpKeyPath { get; set; } = new Dictionary<Guid, string>();
    }
}
