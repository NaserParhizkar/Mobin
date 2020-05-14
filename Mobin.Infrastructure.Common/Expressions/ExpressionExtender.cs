using Mobin.Common.Dynamics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Mobin.Common.Expressions
{
    public static class ExpressionHelper
    {
        public static string GetExpressionText(string expression)
        {
            return
                String.Equals(expression, "model", StringComparison.OrdinalIgnoreCase)
                    ? String.Empty // If it's exactly "model", then give them an empty string, to replicate the lambda behavior
                    : expression;
        }

        public static string GetExpressionText(LambdaExpression expression)
        {
            // Split apart the expression string for property/field accessors to create its name
            Stack<string> nameParts = new Stack<string>();
            Expression part = expression.Body;

            while (part != null)
            {
                if (part.NodeType == ExpressionType.Call)
                {
                    MethodCallExpression methodExpression = (MethodCallExpression)part;

                    if (!IsSingleArgumentIndexer(methodExpression))
                    {
                        break;
                    }

                    nameParts.Push(
                        GetIndexerInvocation(
                            methodExpression.Arguments.Single(),
                            expression.Parameters.ToArray()));

                    part = methodExpression.Object;
                }
                else if (part.NodeType == ExpressionType.ArrayIndex)
                {
                    BinaryExpression binaryExpression = (BinaryExpression)part;

                    nameParts.Push(
                        GetIndexerInvocation(
                            binaryExpression.Right,
                            expression.Parameters.ToArray()));

                    part = binaryExpression.Left;
                }
                else if (part.NodeType == ExpressionType.MemberAccess)
                {
                    MemberExpression memberExpressionPart = (MemberExpression)part;
                    nameParts.Push("." + memberExpressionPart.Member.Name);
                    part = memberExpressionPart.Expression;
                }
                else if (part.NodeType == ExpressionType.Parameter)
                {
                    // Dev10 Bug #907611
                    // When the expression is parameter based (m => m.Something...), we'll push an empty
                    // string onto the stack and stop evaluating. The extra empty string makes sure that
                    // we don't accidentally cut off too much of m => m.Model.
                    nameParts.Push(String.Empty);
                    part = null;
                }
                else
                {
                    break;
                }
            }

            // If it starts with "model", then strip that away
            if (nameParts.Count > 0 && String.Equals(nameParts.Peek(), ".model", StringComparison.OrdinalIgnoreCase))
            {
                nameParts.Pop();
            }

            if (nameParts.Count > 0)
            {
                return nameParts.Aggregate((left, right) => left + right).TrimStart('.');
            }

            return String.Empty;
        }

        private static string GetIndexerInvocation(Expression expression, ParameterExpression[] parameters)
        {
            Expression converted = Expression.Convert(expression, typeof(object));
            ParameterExpression fakeParameter = Expression.Parameter(typeof(object), null);
            Expression<Func<object, object>> lambda = Expression.Lambda<Func<object, object>>(converted, fakeParameter);
            Func<object, object> func;

            try
            {
                func = lambda.Compile();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(
                    String.Format(
                        CultureInfo.CurrentCulture,
                        "asd",
                        expression,
                        parameters[0].Name),
                    ex);
            }

            return "[" + Convert.ToString(func(null), CultureInfo.InvariantCulture) + "]";
        }

        public static bool IsSingleArgumentIndexer(Expression expression)
        {
            MethodCallExpression methodCallExpression = expression as MethodCallExpression;
            if (methodCallExpression == null || methodCallExpression.Arguments.Count != 1)
            {
                return false;
            }
            Type declaringType = methodCallExpression.Method.DeclaringType;
            DefaultMemberAttribute customAttribute = declaringType.GetTypeInfo().GetCustomAttribute<DefaultMemberAttribute>(inherit: true);
            if (customAttribute == null)
            {
                return false;
            }
            foreach (PropertyInfo runtimeProperty in declaringType.GetRuntimeProperties())
            {
                if (string.Equals(customAttribute.MemberName, runtimeProperty.Name, StringComparison.Ordinal) && runtimeProperty.GetMethod == methodCallExpression.Method)
                {
                    return true;
                }
            }
            return false;
        }

    }



    public static class ExpressionExtender
    {
        static int traverse = 0;
        static readonly object threadSafeTravers = new object();

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
                for (var j = 0; j < dynamicProps.Length; j++)
                {
                    var value = (Expression)expressions[i].GetPropertyValue("Body", false);

                    if (value != null)
                    {
                        var memberExp = (MemberExpression)(expressions[i].GetPropertyValue("Body"));
                        var memberName = memberExp.Member.Name;

                        var expLen = memberExp.ToString().Split('.').Length;
                        var diff = expLen - traverse;
                        //x.Order.Employee.ReportsToNavigation.FirstName contain three nested json object
                        //new {order = new { Employee = new { ReportsToNavigation = new { FirstName = ??}}}}
                        //then diff variable must be 2 always      diff == 2   is true
                        if (memberName == dynamicProps[j].Name && diff == 2)
                        {
                            if (members_AssignmentExpression.All(t => t.Member.Name != dynamicProps[j].Name))
                            {
                                members_AssignmentExpression.Add(dynamicProps[j].BindNestedExpression(memberExp));
                                expressions.RemoveAt(i);
                                if (i != 0 && j == dynamicProps.Length - 1)
                                    break;
                                if (expressions.Count == i)
                                    break;
                            }
                        }
                        else
                        {
                            if (!dynamicProps[j].PropertyType.IsSealed && dynamicProps[j].PropertyType.GetProperties().Any())
                            {
                                if (!members_AssignmentExpression.Any(t => t.Expression.Type == dynamicProps[j].PropertyType))
                                {
                                    traverse++;
                                    var newExp = MakeInitExpression(dynamicProps[j].PropertyType, expressions);
                                    var bindToProperty = Expression.Bind(dynamicProps[j], newExp);
                                    members_AssignmentExpression.Add(bindToProperty);
                                    traverse--;
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
            traverse = 0;
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

        public static Expression MakeItAsSimpleExpession(this Expression expression)
        {
            var body = (Expression)expression.GetPropertyValue(nameof(LambdaExpression.Body));//arguments
            return body;
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
