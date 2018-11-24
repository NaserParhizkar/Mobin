using System;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;
using Expr = System.Linq.Expressions.Expression;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Deserializer
    {
        private ConstantExpression ConstantExpression(
            ExpressionType nodeType, System.Type type, JObject obj)
        {
            object value;

            var valueTok = this.Prop(obj, "Value");
            if (valueTok == null || valueTok.Type == JTokenType.Null) {
                value = null;
            }
            else {
                var valueObj = (JObject) valueTok;
                var valueType = this.Prop(valueObj, "Type", this.Type);
                value = this.Deserialize(this.Prop(valueObj, "Value"), valueType);
            }

            switch (nodeType) {
                case ExpressionType.Constant:
                    return Expr.Constant(value, type);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
