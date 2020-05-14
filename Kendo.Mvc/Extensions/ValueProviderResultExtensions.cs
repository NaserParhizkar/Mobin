using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace Kendo.Mvc.Extensions
{
    public static class ValueProviderResultExtensions
    {
        internal static T ConvertValueTo<T>(this ValueProviderResult result)
        {
            object obj = null;
            if (result.Values.Count == 1)
            {
                obj = result.FirstValue;
            }
            else
            {
                if (result.Values.Count > 1)
                {
                    obj = result.Values.ToArray();
                }
            }
            return ModelBindingHelper.ConvertTo<T>(obj, result.Culture);
        }
        public static object ConvertValueTo(this ValueProviderResult result, Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            object obj = null;
            if (result.Values.Count == 1)
            {
                obj = result.FirstValue;
            }
            else
            {
                if (result.Values.Count > 1)
                {
                    obj = result.Values.ToArray();
                }
            }
            object result2 = null;
            try
            {
                result2 = ModelBindingHelper.ConvertTo(obj, type, result.Culture);
            }
            catch
            {
            }
            return result2;
        }
    }



    public static class ModelBindingHelper
    {
        /// <summary>
        /// Converts the provided <paramref name="value" /> to a value of <see cref="T:System.Type" /> <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The <see cref="T:System.Type" /> for conversion.</typeparam>
        /// <param name="value">The value to convert."/&gt;</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> for conversion.</param>
        /// <returns>
        /// The converted value or the default value of <typeparamref name="T" /> if the value could not be converted.
        /// </returns>
        public static T ConvertTo<T>(object value, CultureInfo culture)
        {
            object obj = ConvertTo(value, typeof(T), culture);
            if (obj != null)
            {
                return (T)obj;
            }
            return default(T);
        }

        /// <summary>
        /// Converts the provided <paramref name="value" /> to a value of <see cref="T:System.Type" /> <paramref name="type" />.
        /// </summary>
        /// <param name="value">The value to convert."/&gt;</param>
        /// <param name="type">The <see cref="T:System.Type" /> for conversion.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> for conversion.</param>
        /// <returns>
        /// The converted value or <c>null</c> if the value could not be converted.
        /// </returns>
        public static object ConvertTo(object value, Type type, CultureInfo culture)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (value == null)
            {
                if (!type.GetTypeInfo().IsValueType)
                {
                    return null;
                }
                return Activator.CreateInstance(type);
            }
            if (type.IsAssignableFrom(value.GetType()))
            {
                return value;
            }
            CultureInfo culture2 = culture ?? CultureInfo.InvariantCulture;
            return UnwrapPossibleArrayType(value, type, culture2);
        }

        private static object UnwrapPossibleArrayType(object value, Type destinationType, CultureInfo culture)
        {
            Array array = value as Array;
            if (destinationType.IsArray)
            {
                Type elementType = destinationType.GetElementType();
                if (array != null)
                {
                    IList list = Array.CreateInstance(elementType, array.Length);
                    for (int i = 0; i < array.Length; i++)
                    {
                        list[i] = ConvertSimpleType(array.GetValue(i), elementType, culture);
                    }
                    return list;
                }
                object value2 = ConvertSimpleType(value, elementType, culture);
                Array array2 = Array.CreateInstance(elementType, 1);
                ((IList)array2)[0] = value2;
                return array2;
            }
            if (array != null)
            {
                if (array.Length > 0)
                {
                    value = array.GetValue(0);
                    return ConvertSimpleType(value, destinationType, culture);
                }
                return null;
            }
            return ConvertSimpleType(value, destinationType, culture);
        }

        private static object ConvertSimpleType(object value, Type destinationType, CultureInfo culture)
        {
            if (value == null || destinationType.IsAssignableFrom(value.GetType()))
            {
                return value;
            }
            destinationType = UnwrapNullableType(destinationType);
            string value2;
            if ((value2 = (value as string)) != null && string.IsNullOrWhiteSpace(value2))
            {
                return null;
            }
            TypeConverter converter = TypeDescriptor.GetConverter(destinationType);
            bool flag = converter.CanConvertFrom(value.GetType());
            if (!flag)
            {
                converter = TypeDescriptor.GetConverter(value.GetType());
            }
            if (!flag && !converter.CanConvertTo(destinationType))
            {
                if (destinationType.GetTypeInfo().IsEnum && (value is int || value is uint || value is long || value is ulong || value is short || value is ushort || value is byte || value is sbyte))
                {
                    return Enum.ToObject(destinationType, value);
                }
                throw new InvalidOperationException("");
            }
            try
            {
                return flag ? converter.ConvertFrom(null, culture, value) : converter.ConvertTo(null, culture, value, destinationType);
            }
            catch (FormatException)
            {
                throw;
            }
            catch (Exception ex2)
            {
                if (ex2.InnerException == null)
                {
                    throw;
                }
                ExceptionDispatchInfo.Capture(ex2.InnerException).Throw();
                throw;
            }
        }

        private static Type UnwrapNullableType(Type destinationType)
        {
            return Nullable.GetUnderlyingType(destinationType) ?? destinationType;
        }
    }
}
