using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Exp = System.Linq.Expressions.Expression;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Deserializer
    {
        private readonly Dictionary<string, ParameterExpression> _parameterExpression = new Dictionary<string, ParameterExpression>();


        private ParameterExpression ParameterExpression(ExpressionType nodeType, System.Type type, JObject obj)
        {
            var name = this.Prop(obj, "Name", t => t.Value<string>());

            ParameterExpression result;

            if (_parameterExpression.TryGetValue(name, out result))
                return result;

            switch (nodeType)
            {
                case ExpressionType.Parameter:
                    result = Exp.Parameter(type, name);
                    break;
                default:
                    throw new NotSupportedException();
            }

            _parameterExpression[name] = result;
            return result;
        }

        private ParameterExpression ParameterExpression(JToken token)
        {
            if (token == null || token.Type != JTokenType.Object)
                return null;

            var obj = (JObject)token;
            var nodeType = this.Prop(obj, "NodeType", this.Enum<ExpressionType>);
            var type = this.Prop(obj, "Type", this.Type);
            var typeName = this.Prop(obj, "TypeName", t => t.Value<string>());

            if (typeName != "Parameter")
                return null;

            return this.ParameterExpression(nodeType, type, obj);
        }
    }
}
