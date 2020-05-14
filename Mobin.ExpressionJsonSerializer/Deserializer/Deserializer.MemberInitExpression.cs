using Newtonsoft.Json.Linq;
using System;
using System.Linq.Expressions;
using Expr = System.Linq.Expressions.Expression;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Deserializer
    {
        private MemberInitExpression MemberInitExpression(
            ExpressionType nodeType, System.Type type, JObject obj)
        {
            var expression = (NewExpression)this.Prop(obj, "Expression", this.Expression);
            var bindings = this.Prop(obj, "Bindings", this.Enumerable(this.MemberBinding));


            switch (nodeType)
            {
                case ExpressionType.MemberInit:
                    return Expr.MemberInit(expression, bindings);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
