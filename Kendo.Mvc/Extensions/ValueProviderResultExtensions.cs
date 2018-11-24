using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Internal;
using System;

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
}
