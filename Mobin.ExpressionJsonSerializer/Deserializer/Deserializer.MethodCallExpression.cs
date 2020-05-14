using Newtonsoft.Json.Linq;
using System;
using System.Linq.Expressions;
using Expr = System.Linq.Expressions.Expression;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Deserializer
    {
        private MethodCallExpression MethodCallExpression(
            ExpressionType nodeType, System.Type type, JObject obj)
        {
            var instance = this.Prop(obj, "Object", this.Expression);
            var method = this.Prop(obj, "Method", this.Method);
            var arguments = this.Prop(obj, "Arguments", this.Enumerable(this.Expression));

            switch (nodeType)
            {
                case ExpressionType.ArrayIndex:
                    return Expr.ArrayIndex(instance, arguments);
                case ExpressionType.Call:
                    return Expr.Call(instance, method, arguments);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
