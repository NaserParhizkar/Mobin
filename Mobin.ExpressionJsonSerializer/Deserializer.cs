using Mobin.Common.Dynamics;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Mobin.ExpressionJsonSerializer
{
    internal partial class Deserializer
    {
        public static Expression Deserialize(Assembly assembly, JToken token)
        {
            var d = new Deserializer(assembly);
            d.RegisterAnonymousType(assembly, token);

            return d.Expression(token);
        }

        public void RegisterAnonymousType(Assembly assembly, JToken token)
        {
            var obj = (JObject)token;
            var bodyToken = this.Prop(obj, "Body");

            var bodyObj = (JObject)bodyToken;
            var typeToken = this.Prop(bodyObj, "Type");

            var typeNameObj = (JObject)typeToken;
            var typeNameToken = this.Prop(typeNameObj, "TypeName", t => t.Value<string>());

            Type dynamicType = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(ass => ass.GetName().Name == "DynamicClasses")?.GetType(typeNameToken);
        }

        //private static Type GetDynamicClass(Dictionary<string, Type> properties)
        //{
        //    List<DynamicProperty> dynamicProperties = new List<DynamicProperty>();
        //    foreach (var property in properties)
        //    {
        //        var dynamicProperty = new DynamicProperty(property.Key, property.Value);
        //        dynamicProperties.Add(dynamicProperty);
        //    }

        //    return ClassFactory.Instance.GetDynamicClass(dynamicProperties);
        //}

        private readonly Assembly _assembly;

        private Deserializer(Assembly assembly)
        {
            this._assembly = assembly;
        }

        private object Deserialize(JToken token, System.Type type)
        {
            return token.ToObject(type);
        }

        private T Prop<T>(JObject obj, string name, Func<JToken, T> result)
        {
            var prop = obj.Property(name);
            return result(prop == null ? null : prop.Value);
        }

        private JToken Prop(JObject obj, string name)
        {
            return obj.Property(name).Value;
        }

        private T Enum<T>(JToken token)
        {
            return (T)System.Enum.Parse(typeof(T), token.Value<string>());
        }

        private Func<JToken, IEnumerable<T>> Enumerable<T>(Func<JToken, T> result)
        {
            return token =>
            {
                if (token == null || token.Type != JTokenType.Array)
                    return null;
                var array = (JArray)token;
                return array.Select(result);
            };
        }

        private Expression Expression(JToken token)
        {
            if (token == null || token.Type != JTokenType.Object)
            {
                return null;
            }

            var obj = (JObject)token;
            var nodeType = this.Prop(obj, "NodeType", this.Enum<ExpressionType>);
            var type = this.Prop(obj, "Type", this.Type);
            var typeName = this.Prop(obj, "TypeName", t => t.Value<string>());

            if (nodeType == ExpressionType.New)
                type = this.Prop(obj, "Type", this.Type);


            switch (typeName)
            {
                case "Binary": return this.BinaryExpression(nodeType, type, obj);
                case "Block": return this.BlockExpression(nodeType, type, obj);
                case "Conditional": return this.ConditionalExpression(nodeType, type, obj);
                case "Constant": return this.ConstantExpression(nodeType, type, obj);
                case "DebugInfo": return this.DebugInfoExpression(nodeType, type, obj);
                case "Default": return this.DefaultExpression(nodeType, type, obj);
                case "Dynamic": return this.DynamicExpression(nodeType, type, obj);
                case "Goto": return this.GotoExpression(nodeType, type, obj);
                case "Index": return this.IndexExpression(nodeType, type, obj);
                case "Invocation": return this.InvocationExpression(nodeType, type, obj);
                case "Label": return this.LabelExpression(nodeType, type, obj);
                case "Lambda": return this.LambdaExpression(nodeType, type, obj);
                case "ListInit": return this.ListInitExpression(nodeType, type, obj);
                case "Loop": return this.LoopExpression(nodeType, type, obj);
                case "Member": return this.MemberExpression(nodeType, type, obj);
                case "MemberInit": return this.MemberInitExpression(nodeType, type, obj);
                case "MethodCall": return this.MethodCallExpression(nodeType, type, obj);
                case "NewArray": return this.NewArrayExpression(nodeType, type, obj);
                case "New": return this.NewExpression(nodeType, type, obj);
                case "Parameter": return this.ParameterExpression(nodeType, type, obj);
                case "RuntimeVariables": return this.RuntimeVariablesExpression(nodeType, type, obj);
                case "Switch": return this.SwitchExpression(nodeType, type, obj);
                case "Try": return this.TryExpression(nodeType, type, obj);
                case "TypeBinary": return this.TypeBinaryExpression(nodeType, type, obj);
                case "Unary": return this.UnaryExpression(nodeType, type, obj);
            }
            throw new NotSupportedException();
        }
    }
}
