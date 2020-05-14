using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Serializer
    {

        private static readonly Dictionary<Type, Tuple<string, string, Type[]>>
            TypeCache = new Dictionary<Type, Tuple<string, string, Type[]>>();

        private Action Type(Type type)
        {
            return () => this.TypeInternal(type);
        }

        private void TypeInternal(Type type)
        {
            if (type == null)
            {
                this._writer.WriteNull();
            }
            else
            {
                Tuple<string, string, Type[]> tuple;
                if (!TypeCache.TryGetValue(type, out tuple))
                {
                    var assemblyName = type.Assembly.FullName;
                    if (type.IsGenericType)
                    {
                        var def = type.GetGenericTypeDefinition();
                        tuple = new Tuple<string, string, Type[]>(
                            def.Assembly.FullName, def.FullName,
                            type.GetGenericArguments()
                        );
                    }
                    else
                    {
                        tuple = new Tuple<string, string, Type[]>(
                            assemblyName, type.FullName, null);
                    }
                    TypeCache[type] = tuple;
                }

                this._writer.WriteStartObject();
                this.Prop("AssemblyName", tuple.Item1);
                this.Prop("TypeName", tuple.Item2);
                this.Prop("GenericArguments", this.Enumerable(tuple.Item3, this.Type));
                this._writer.WriteEndObject();
            }
        }

        private Action Constructor(ConstructorInfo constructor)
        {
            return () => this.ConstructorInternal(constructor);
        }

        private void ConstructorInternal(ConstructorInfo constructor)
        {
            if (constructor == null)
            {
                this._writer.WriteNull();
            }
            else
            {
                this._writer.WriteStartObject();
                this.Prop("Type", this.Type(constructor.DeclaringType));
                this.Prop("Name", constructor.Name);
                this.Prop("Signature", constructor.ToString());
                this._writer.WriteEndObject();
            }
        }

        private Action Method(MethodInfo method)
        {
            return () => this.MethodInternal(method);
        }

        private void MethodInternal(MethodInfo method)
        {
            if (method == null)
            {
                this._writer.WriteNull();
            }
            else
            {
                this._writer.WriteStartObject();
                if (method.IsGenericMethod)
                {
                    var meth = method.GetGenericMethodDefinition();
                    var generic = method.GetGenericArguments();

                    this.Prop("Type", this.Type(meth.DeclaringType));
                    this.Prop("Name", meth.Name);
                    this.Prop("Signature", meth.ToString());
                    this.Prop("Generic", this.Enumerable(generic, this.Type));
                }
                else
                {
                    this.Prop("type", this.Type(method.DeclaringType));
                    this.Prop("Name", method.Name);
                    this.Prop("Signature", method.ToString());
                }
                this._writer.WriteEndObject();
            }
        }

        private Action Property(PropertyInfo property)
        {
            return () => this.PropertyInternal(property);
        }

        private void PropertyInternal(PropertyInfo property)
        {
            if (property == null)
            {
                this._writer.WriteNull();
            }
            else
            {
                this._writer.WriteStartObject();
                this.Prop("Type", this.Type(property.DeclaringType));
                this.Prop("Name", property.Name);
                this.Prop("Signature", property.ToString());
                this._writer.WriteEndObject();
            }
        }

        private Action Member(MemberInfo member)
        {
            return () => this.MemberInternal(member);
        }

        private void MemberInternal(MemberInfo member)
        {
            if (member == null)
            {
                this._writer.WriteNull();
            }
            else
            {
                this._writer.WriteStartObject();
                this.Prop("Type", this.Type(member.DeclaringType));
                this.Prop("MemberType", (int)member.MemberType);
                this.Prop("Name", member.Name);
                this.Prop("Signature", member.ToString());
                this._writer.WriteEndObject();
            }
        }

        private Action MemberBinding(MemberBinding memberBinding)
        {
            return () => this.MemberBindingInternal(memberBinding);
        }

        private void MemberBindingInternal(MemberBinding memberBinding)
        {
            if (memberBinding == null)
            {
                this._writer.WriteNull();
            }
            else
            {
                this._writer.WriteStartObject();
                this.Prop("Type", this.Type(memberBinding.Member.DeclaringType));
                this.Prop("BindingType", (int)memberBinding.BindingType);
                this.Prop("Name", memberBinding.Member.Name);
                var exp = (Expression)memberBinding.GetType().GetProperty("Expression").GetValue(memberBinding);
                if (exp != null)
                    this.Prop("Expression", this.Expression(exp));


                this._writer.WriteEndObject();
            }
        }
    }
}
