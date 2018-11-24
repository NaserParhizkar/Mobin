using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Expr = System.Linq.Expressions.Expression;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Deserializer
    {
        private LambdaExpression LambdaExpression(ExpressionType nodeType, System.Type type, JObject obj)
        {
            var body = this.Prop(obj, "Body", this.Expression);
            var tailCall = this.Prop(obj, "TailCall").Value<bool>();
            var parameters = this.Prop(obj, "Parameters", this.Enumerable(this.ParameterExpression));

            if (typeof(LambdaExpression).IsAssignableFrom(body.GetType()))
                return (LambdaExpression)body;

            switch (nodeType)
            {
                case ExpressionType.Lambda:
                    return Expr.Lambda(body, tailCall, parameters);
                default: throw new NotSupportedException();
            }
        }

        private LambdaExpression LambdaExpression(JToken token)
        {
            if (token == null || token.Type != JTokenType.Object)
                return null;

            var obj = (JObject)token;
            var nodeType = this.Prop(obj, "NodeType", this.Enum<ExpressionType>);
            var type = this.Prop(obj, "Type", this.Type);
            var typeName = this.Prop(obj, "TypeName", t => t.Value<string>());

            if (typeName != "Lambda")
                return null;

            return this.LambdaExpression(nodeType, type, obj);
        }
    }
}
