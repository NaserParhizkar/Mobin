using Mobin.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Mobin.ExpressionJsonSerializer
{
    public static class ExpressionSaver
    {
        private static readonly object _objThreadSafe = new object();
        public static void SerialExpressionAsJson<T>(this Expression expression, string path, ref Guid? retrieveKey, params Assembly[] refrenceTypeResolvingAssemblies)
        {
            System.Threading.Monitor.Enter(_objThreadSafe);
            try
            {
                if (refrenceTypeResolvingAssemblies.Length == 0)
                    throw new MobinException("Must be specify at least one assembly");

                var serializedLambda = JsonNetAdapter.Serialize(expression, refrenceTypeResolvingAssemblies);
                File.WriteAllText(path, serializedLambda);

                // Set component key and value 
                var oldWidgetId = ExpressionPathKeeper.ExpKeyPath.SingleOrDefault(y => y.Value == path).Key;
                if (oldWidgetId != null && oldWidgetId != Guid.Empty)
                    retrieveKey = oldWidgetId;
                else
                {
                    if (!retrieveKey.HasValue || retrieveKey == Guid.Empty)
                        throw new MobinException($"retrieveKey parameter can not be null or default GUID type value");

                    ExpressionPathKeeper.ExpKeyPath.Add(retrieveKey.Value, path);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                System.Threading.Monitor.Exit(_objThreadSafe);
            }
        }
    }
}
