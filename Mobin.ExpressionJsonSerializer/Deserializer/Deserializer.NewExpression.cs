using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Expr = System.Linq.Expressions.Expression;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Deserializer
    {
        private NewExpression NewExpression(
            ExpressionType nodeType, System.Type type, JObject obj)
        {

            var arguments = this.Prop(obj, "Arguments", this.Enumerable(this.Expression));
            var members = this.Prop(obj, "Members", this.Enumerable(this.Member));
            var constructor = this.Prop(obj, "Constructor", this.Constructor);

            switch (nodeType)
            {
                case ExpressionType.New:
                    if (arguments == null)
                    {
                        if (members == null)
                        {
                            return Expr.New(constructor);
                        }
                        return Expr.New(constructor, new Expression[0], members);
                    }
                    if (members == null)
                    {
                        return Expr.New(constructor, arguments);
                    }
                    return Expr.New(constructor, arguments, members);
                default:
                    throw new NotSupportedException();
            }
        }

        private LambdaExpression CustomNewExpression(
            ExpressionType nodeType, System.Type type, JObject obj)
        {

            var arguments = this.Prop(obj, "Arguments", this.Enumerable(this.Expression));
            var members = this.Prop(obj, "Members", this.Enumerable(this.Member));
            var constructor = this.Prop(obj, "Constructor", this.Constructor);
            return GenerateLambdaExpression(arguments, members);
        }

        private LambdaExpression GenerateLambdaExpression(IEnumerable<Expr> arguments, IEnumerable<MemberInfo> generalMembers)
        {
            var dynamicType = generalMembers.FirstOrDefault().ReflectedType;
            var argumentType = arguments.FirstOrDefault();
            var expression = argumentType.GetType().GetProperty("Expression").GetValue(argumentType);
            var entityType = (Type)expression.GetType().GetProperty("Type").GetValue(expression);

            var members = arguments.Select(t => new { Member = (MemberInfo)t.GetType().GetProperty("Member").GetValue(t) })
                    .Select(r => new
                    {
                        Name = (string)r.Member.GetType().GetProperty("Name").GetValue(r.Member),
                        PropertyType = (PropertyInfo)r.Member
                    });

            Dictionary<string, PropertyInfo> sourceProperties = members.ToDictionary(name => name.Name, name => name.PropertyType);

            ParameterExpression sourceItem = Expr.Parameter(entityType, "x");

            IEnumerable<MemberBinding> bindings = dynamicType.GetProperties().Select(p => Expr.Bind(p,
                Expr.Property(sourceItem, sourceProperties[p.Name]))).OfType<MemberBinding>();

            var ctorParams = dynamicType.GetConstructor(System.Type.EmptyTypes);

            var newExp = Expr.New(ctorParams);

            var selectorExp = Expr.Lambda(Expr.MemberInit(newExp, bindings), sourceItem);

            return selectorExp;
        }
    }
}
