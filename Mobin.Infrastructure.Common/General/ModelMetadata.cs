using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Mobin.Common
{
    public static class Utility
    {
        public static class ModelMetadata<TModel> where TModel : class, new()//Add extra info
        {
            /// <summary>
            /// Get special attribute that you specify as a generic type
            /// </summary>
            /// <typeparam name="TProperty"></typeparam>
            /// <param name="expression">specify property which you want get attribute from</param>
            /// <param name="attribute">type of attribute you want to get</param>
            /// <returns></returns>
            public static TAttribute GetAttribute<TAttribute>(Expression<Func<TModel, dynamic>> expression)
                where TAttribute : Attribute
            {
                var body = expression.GetPropertyValue(nameof(LambdaExpression.Body));
                var memberInfo = (MemberInfo)body.GetPropertyValue(nameof(MemberExpression.Member));
                var attributes = (TAttribute[])memberInfo.GetCustomAttributes<TAttribute>();

                if (attributes == null || attributes.Length == 0)
                    throw new MobinException($"Attribute '{nameof(TAttribute)}' does not exist for '{memberInfo.Name}' property");

                return attributes[0];
            }
        }
    }
}