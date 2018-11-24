using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Mobin.Common
{
    public static class TypeExtender
    {
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> keyValues, IDictionary<TKey, TValue> dictionary)
        {
            foreach (var dic in dictionary)
            {
                keyValues.Add(dic.Key, dic.Value);
            }
        }

        public static PropertyInfo GetInnerProperty(this PropertyInfo propertyInfo, string propertyName, out Type dynamicClass)
        {
            dynamicClass = propertyInfo.PropertyType;

            if (propertyInfo.PropertyType.GetProperty(propertyName) != null)
            {
                return propertyInfo.PropertyType.GetProperty(propertyName);
            }
            else
            {
                foreach (var prop in propertyInfo.PropertyType.GetProperties())
                {
                    if (prop.PropertyType.GetProperties().Length > 0)
                    {
                        Type type = prop.PropertyType;
                        var p = GetInnerProperty(prop, propertyName, out type);
                        if (p != null)
                        {
                            dynamicClass = prop.PropertyType;
                            return p;
                        }
                    }
                    else
                    {
                        if (prop.Name == propertyName)
                            return prop;
                    }
                }
                return null;
            }
        }

        public static object GetPropertyValue<TType>(this TType instance, string propertyName, bool ifNullThrownException = true)
        {
            var prop = instance.GetType().GetProperty(propertyName);
            if (prop == null)
            {
                if (ifNullThrownException)
                    throw new MobinException($"Type '{typeof(TType) }' doesnt have property {propertyName}");
                return null;
            }
            return prop.GetValue(instance);
        }
    }
}
