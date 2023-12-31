﻿using Newtonsoft.Json.Linq;
using System;
using System.Linq.Expressions;
using Expr = System.Linq.Expressions.Expression;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Deserializer
    {
        private DefaultExpression DefaultExpression(
            ExpressionType nodeType, System.Type type, JObject obj)
        {
            switch (nodeType)
            {
                case ExpressionType.Default:
                    return Expr.Default(type);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
