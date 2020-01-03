using System;
using System.Collections.Generic;

namespace Mobin.ExpressionJsonSerializer
{
    public static class ExpressionPathKeeper
    {
        public static IDictionary<Guid, string> ExpKeyPath { get; set; } = new Dictionary<Guid, string>();
    }
}
