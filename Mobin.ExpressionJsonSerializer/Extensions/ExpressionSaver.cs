using Mobin.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Mobin.ExpressionJsonSerializer
{
    public static class ExpressionSaver
    {
        public static void SerialExpressionAsJson<T>(this Expression expression, string path, params Assembly[] refrenceTypeResolvingAssemblies)
        {
            try
            {
                if (refrenceTypeResolvingAssemblies.Length == 0)
                    throw new MobinException("Must be specify at least one assembly");

                var serializedLambda = JsonNetAdapter.Serialize(expression, refrenceTypeResolvingAssemblies);
                File.WriteAllText(path, serializedLambda);
            }
            catch
            {
                throw;
            }
        }
    }
}
