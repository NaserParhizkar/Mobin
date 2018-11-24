using System;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;
using Expr = System.Linq.Expressions.Expression;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Deserializer
    {
        private ConditionalExpression ConditionalExpression(
            ExpressionType nodeType, System.Type type, JObject obj)
        {
            var test = this.Prop(obj, "Test", this.Expression);
            var ifTrue = this.Prop(obj, "IfTrue", this.Expression);
            var ifFalse = this.Prop(obj, "IfFalse", this.Expression);

            switch (nodeType) {
                case ExpressionType.Conditional:
                    return Expr.Condition(test, ifTrue, ifFalse, type);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
