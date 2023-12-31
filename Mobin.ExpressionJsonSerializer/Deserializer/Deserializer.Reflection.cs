﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Deserializer
    {
        private readonly static object _threadSafeObj = new object();

        private static readonly Dictionary<Assembly, Dictionary<string, Dictionary<string, Type>>>
            TypeCache = new Dictionary<Assembly, Dictionary<string, Dictionary<string, Type>>>();

        private static readonly Dictionary<Type, Dictionary<string, Dictionary<string, ConstructorInfo>>>
            ConstructorCache = new Dictionary<Type, Dictionary<string, Dictionary<string, ConstructorInfo>>>();

        private Type Type(JToken token)
        {
            System.Threading.Monitor.Enter(_threadSafeObj);
            if (token == null || token.Type != JTokenType.Object)
            {
                return null;
            }

            var obj = (JObject)token;
            var assemblyName = this.Prop(obj, "AssemblyName", t => t.Value<string>());
            var typeName = this.Prop(obj, "TypeName", t => t.Value<string>());
            var generic = this.Prop(obj, "GenericArguments", this.Enumerable(this.Type));

            Dictionary<string, Dictionary<string, Type>> assemblies;
            if (!TypeCache.TryGetValue(this._assembly, out assemblies))
            {
                assemblies = new Dictionary<string, Dictionary<string, Type>>();
                TypeCache[this._assembly] = assemblies;
            }

            Dictionary<string, Type> types;
            if (!assemblies.TryGetValue(assemblyName, out types))
            {
                types = new Dictionary<string, Type>();
                assemblies[assemblyName] = types;
            }

            Type type;
            if (!types.TryGetValue(typeName, out type))
            {
                var dynamicLinqAssembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly =>
                    assembly.GetName().Name.Contains("DynamicClasses"));
                if (dynamicLinqAssembly != null)
                    type = dynamicLinqAssembly.GetType(typeName);

                if (type == null)
                    type = this._assembly.GetType(typeName);

                if (type == null)
                {
                    var assembly = Assembly.Load(new AssemblyName(assemblyName));
                    type = assembly.GetType(typeName);
                }
                //if (type == null)
                //{
                //    throw new Exception(
                //        "Type could not be found: "
                //        + assemblyName + "." + typeName
                //    );
                //}
                types[typeName] = type;
            }

            if (generic != null && type.IsGenericTypeDefinition)
            {
                type = type.MakeGenericType(generic.ToArray());
            }

            System.Threading.Monitor.Exit(_threadSafeObj);

            return type;
        }

        private ConstructorInfo Constructor(JToken token)
        {
            System.Threading.Monitor.Enter(_threadSafeObj);

            if (token == null || token.Type != JTokenType.Object)
            {
                return null;
            }

            var obj = (JObject)token;
            var type = this.Prop(obj, "Type", this.Type);
            var name = this.Prop(obj, "Name").Value<string>();
            var signature = this.Prop(obj, "Signature").Value<string>();

            ConstructorInfo constructor;
            Dictionary<string, ConstructorInfo> cache2;
            Dictionary<string, Dictionary<string, ConstructorInfo>> cache1;

            if (!ConstructorCache.TryGetValue(type, out cache1))
            {
                constructor = this.ConstructorInternal(type, name, signature);

                cache2 = new Dictionary<
                    string, ConstructorInfo>(1) {
                        {signature, constructor}
                    };

                cache1 = new Dictionary<
                    string, Dictionary<
                        string, ConstructorInfo>>(1) {
                            {name, cache2}
                        };

                ConstructorCache[type] = cache1;
            }
            else if (!cache1.TryGetValue(name, out cache2))
            {
                constructor = this.ConstructorInternal(type, name, signature);

                cache2 = new Dictionary<
                    string, ConstructorInfo>(1) {
                        {signature, constructor}
                    };

                cache1[name] = cache2;
            }
            else if (!cache2.TryGetValue(signature, out constructor))
            {
                constructor = this.ConstructorInternal(type, name, signature);
                cache2[signature] = constructor;
            }

            System.Threading.Monitor.Exit(_threadSafeObj);

            return constructor;
        }

        private ConstructorInfo ConstructorInternal(
            Type type, string name, string signature)
        {
            var constructor = type
                .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(c => c.Name == name && c.ToString() == signature);

            if (constructor == null)
            {
                constructor = type
                    .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(c => c.Name == name && c.ToString() == signature);

                if (constructor == null)
                    constructor = type.GetConstructor(System.Type.EmptyTypes);

                if (constructor == null)
                {
                    throw new Exception(
                        "Constructor for type \""
                        + type.FullName +
                        "\" with signature \""
                        + signature +
                        "\" could not be found"
                    );
                }
            }

            return constructor;
        }

        private MethodInfo Method(JToken token)
        {
            if (token == null || token.Type != JTokenType.Object)
            {
                return null;
            }

            var obj = (JObject)token;
            var type = this.Prop(obj, "Type", this.Type);
            var name = this.Prop(obj, "Name").Value<string>();
            var signature = this.Prop(obj, "Signature").Value<string>();
            var generic = this.Prop(obj, "Generic", this.Enumerable(this.Type));

            var methods = type.GetMethods(
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static
            );
            var method = methods.First(m => m.Name == name && m.ToString() == signature);

            if (generic != null && method.IsGenericMethodDefinition)
            {
                method = method.MakeGenericMethod(generic.ToArray());
            }

            return method;
        }

        private PropertyInfo Property(JToken token)
        {
            if (token == null || token.Type != JTokenType.Object)
            {
                return null;
            }

            var obj = (JObject)token;
            var type = this.Prop(obj, "Type", this.Type);
            var name = this.Prop(obj, "Name").Value<string>();
            var signature = this.Prop(obj, "Signature").Value<string>();

            var properties = type.GetProperties(
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static
            );
            return properties.First(p => p.Name == name && p.ToString() == signature);
        }

        private MemberInfo Member(JToken token)
        {
            if (token == null || token.Type != JTokenType.Object)
            {
                return null;
            }

            var obj = (JObject)token;
            var type = this.Prop(obj, "Type", this.Type);
            var name = this.Prop(obj, "Name").Value<string>();
            var signature = this.Prop(obj, "Signature").Value<string>();
            var memberType = (MemberTypes)this.Prop(obj, "MemberType").Value<int>();

            memberType = MemberTypes.Field;

            var members = type.GetMembers(
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static
            );
            return members.First(p => (p.MemberType == memberType || p.MemberType == MemberTypes.Property)
                && p.Name == name && p.ToString() == signature);
        }

        private MemberAssignment MemberBinding(JToken token)
        {
            var obj = (JObject)token;
            var dynamicType = this.Prop(obj, "Type", this.Type);
            var propertyName = this.Prop(obj, "Name").Value<string>();
            var memberExpression = this.Prop(obj, "Expression", this.Expression);
            var bindingType = (MemberBindingType)this.Prop(obj, "BindingType").Value<int>();

            var dynamicProp = dynamicType.GetProperty(propertyName);

            return System.Linq.Expressions.Expression.Bind(dynamicProp, memberExpression);
        }
    }
}
