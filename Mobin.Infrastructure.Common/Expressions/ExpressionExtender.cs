using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Mobin.Common;
using Mobin.Common.Dynamics;

namespace Mobin.Common.Expressions
{
    public static class ExpressionExtender
    {
        public static MemberExpression GetMemberExpression(this ParameterExpression parameterExpression, MemberExpression memberExpression)
        {
            var isParameterExpression = memberExpression.Expression is ParameterExpression;

            if (isParameterExpression)
            {
                return Expression.Property(parameterExpression, memberExpression.Member.Name);
            }
            else
            {
                var tempMemberExpr = (MemberExpression)memberExpression.Expression;
                var recursiveResultMemberExpr = GetMemberExpression(parameterExpression, tempMemberExpr);

                return Expression.Property(recursiveResultMemberExpr, memberExpression.Member.Name);
            }
        }

        public static string GetRootMemberExpressionName(this MemberExpression memberExpression)
        {
            var isParameterExpression = memberExpression.Expression is ParameterExpression;

            if (isParameterExpression)
                return memberExpression.Member.Name;
            else
                return GetRootMemberExpressionName((MemberExpression)memberExpression.Expression);
        }

        public static MemberAssignment BindNestedExpression(this PropertyInfo propertyInfo, MemberExpression memberExpression)
        {
            var propertyName = memberExpression.Member.Name;
            var lstMemberAssignment = new List<MemberAssignment>();

            if (propertyInfo.Name == propertyName)
            {
                return Expression.Bind(propertyInfo, memberExpression);
            }
            else
            {
                Type dynamicCls = propertyInfo.PropertyType;
                var propInfo = propertyInfo.GetInnerProperty(propertyName, out dynamicCls);


                var recursiveExprBinding = propInfo.BindNestedExpression(memberExpression);
                lstMemberAssignment.Add(recursiveExprBinding);
                var makeBindingExpr = Expression.MemberInit(Expression.New(dynamicCls), lstMemberAssignment);


                return Expression.Bind(propertyInfo, makeBindingExpr);
            }
        }

        public static MemberInitExpression MakeInitExpression(this Type dynamicClassType, List<Expression> expressions)
        {
            var dynamicProps = dynamicClassType.GetProperties();
            var members_AssignmentExpression = new List<MemberAssignment>();

            for (int i = 0; i < expressions.Count; i++)
            {
                foreach (var prop in dynamicProps)
                {
                    var value = (Expression)expressions[i].GetPropertyValue("Body", false);

                    if (value != null)
                    {
                        var memberExp = (MemberExpression)(expressions[i].GetPropertyValue("Body"));
                        var memberName = memberExp.Member.Name;

                        if (memberName == prop.Name)
                        {
                            members_AssignmentExpression.Add(prop.BindNestedExpression(memberExp));
                            expressions.RemoveAt(i);
                            if (i != 0)
                                break;
                        }
                        else
                        {
                            if (!prop.PropertyType.IsSealed && prop.PropertyType.GetProperties().Any())
                            {
                                if (!members_AssignmentExpression.Any(t => t.Expression.Type == prop.PropertyType))
                                {
                                    var newExp = MakeInitExpression(prop.PropertyType, expressions);
                                    var bindToProperty = Expression.Bind(prop, newExp);

                                    members_AssignmentExpression.Add(bindToProperty);
                                }
                            }
                        }
                    }
                }
            }

            return Expression.MemberInit(Expression.New(dynamicClassType), members_AssignmentExpression);
        }

        public static LambdaExpression GetLambdaExpression<T>(this List<Expression> expressions)
        {
            ParameterExpression sourceItem = Expression.Parameter(typeof(T), "x");
            var memberExprList = new List<MemberAssignment>();

            Type dynamicType = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(ass => ass.GetName().Name == "DynamicLinqTypes")?.GetType("Anonymous");
            if (dynamicType == null)
                dynamicType = expressions.GetDynamicClass();

            var expr = dynamicType.MakeInitExpression(expressions);

            return Expression.Lambda(expr, new ParameterExpression[] { (ParameterExpression)sourceItem });
        }

        public static Type GetDynamicClass(this List<Expression> expressions)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();

            foreach (var exp in expressions)
            {
                var value = (Expression)exp.GetPropertyValue("Body", false);
                if (value != null)
                {
                    var memberExp = (MemberExpression)exp.GetPropertyValue("Body", false);
                    var props = MakeDynamicClass(memberExp).ToList();

                    props.ForEach(w =>
                    {
                        if (properties.ContainsKey(w.Key))
                            SetValueInDictionary(properties, w.Key, (IDictionary<string, object>)w.Value);
                        else
                            properties.Add(w.Key, w.Value);
                    });
                }
            }

            return GetDynamicClass(properties);
        }

        internal static Type GetDynamicClass(IDictionary<string, object> properties)
        {
            var dictionary = new Dictionary<string, Type>();
            foreach (var prop in properties)
            {
                if (prop.Value is Type)
                {
                    dictionary.Add(prop.Key, (Type)prop.Value);
                }
                else
                {
                    if (prop.Value is IDictionary)
                    {
                        Type typeRes = null;
                        if (prop.Value is IDictionary<string, Type>)
                        {
                            var typeDic = (IDictionary<string, Type>)prop.Value;
                            typeRes = GetDynamicClass(GetObjectDictionary(typeDic));
                            dictionary.Add(prop.Key, typeRes);
                        }
                        else
                        {
                            typeRes = GetDynamicClass((IDictionary<string, object>)prop.Value);
                            dictionary.Add(prop.Key, typeRes);
                        }
                    }
                    else
                        throw new MobinException("Type of value in dictionary is not correct");
                }
            }
            return ClassFactory.Instance.GetDynamicClass(dictionary);
        }

        internal static IDictionary<string, object> GetObjectDictionary(IDictionary<string, Type> dic)
        {
            var res = new Dictionary<string, object>();
            foreach (var item in dic)
            {
                res.Add(item.Key, item.Value);
            }
            return res;
        }

        internal static IDictionary<string, object> MakeDynamicClass(Expression expression)
        {
            var memberExpression = (MemberExpression)expression;
            IDictionary<string, object> properties = new Dictionary<string, object>();

            if (memberExpression == null)
                throw new MobinException("Expression must be of type MemberExpression");

            if (memberExpression.Expression is ParameterExpression)
            {
                var propName = memberExpression.Member.Name;
                var propType = ((PropertyInfo)memberExpression.Member).PropertyType;
                properties.Add(propName, propType);
            }
            else
            {
                IDictionary<string, object> childsMembers = new Dictionary<string, object>();
                childsMembers.Add(memberExpression.Member.Name, ((PropertyInfo)memberExpression.Member).PropertyType);

                var props = MakeDynamicClass(memberExpression.Expression);
                var parentMemberName = ((MemberExpression)memberExpression.Expression).Member.Name;

                properties = SetValueInDictionary(props, parentMemberName, childsMembers);
            }

            return properties;
        }

        internal static IDictionary<string, object> SetValueInDictionary(IDictionary<string, object> parent, string key,
            IDictionary<string, object> child)
        {
            if (parent.ContainsKey(key))
            {
                if (parent[key] is IDictionary<string, Type>)
                {
                    var tempDic = (IDictionary<string, Type>)parent[key];
                }
                else if (parent[key] is IDictionary<string, object>)
                {
                    var flag = false;
                    var tempDic = (IDictionary<string, object>)parent[key];
                    child.Keys.ToList().ForEach(y =>
                    {
                        if (flag = tempDic.ContainsKey(y))
                            SetValueInDictionary(tempDic, y, (IDictionary<string, object>)child[y]);
                    });

                    if (!flag)
                        tempDic.AddRange(child);
                }
                else
                    parent[key] = child;
            }
            else
            {
                foreach (IDictionary<string, object> item in parent.Values)
                {
                    var recursiveDic = SetValueInDictionary(item, key, child);
                    return parent;
                }
            }
            return parent;
        }
    }
}
