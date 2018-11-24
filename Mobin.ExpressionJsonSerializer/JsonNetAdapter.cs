using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Mobin.ExpressionJsonSerializer
{
    public static class JsonNetAdapter
    {
        private static readonly JsonSerializerSettings _settings;

        static JsonNetAdapter()
        {
            var defaultSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            _settings = defaultSettings;
        }

        public static string Serialize<T>(T obj) => JsonConvert.SerializeObject(obj, _settings);

        public static string Serialize<T>(T obj, params Assembly[] refrenceTypeResolvingAssemblies)
        {
            foreach (var assembly in refrenceTypeResolvingAssemblies)
            {
                _settings.Converters.Add(new ExpressionJsonConverter(assembly));
            }

            return JsonConvert.SerializeObject(obj, _settings);
        }

        public static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json, _settings);

        public static T Deserialize<T>(string json, params Assembly[] refrenceTypeResolvingAssemblies)
        {
            foreach (var assembly in refrenceTypeResolvingAssemblies)
            {
                _settings.Converters.Add(new ExpressionJsonConverter(assembly));
            }

            return JsonConvert.DeserializeObject<T>(json, _settings);
        }

        public static Expression ReadDeserializedExpression<T>(Guid callerKey)
        {
            string path = string.Empty,
                json = string.Empty;

            using (var stream = File.OpenRead(path))
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            var serializedLambda = Deserialize<Expression>(json, typeof(T).Assembly);
            return serializedLambda;
        }

        public static LambdaExpression ReadDeserializedLambdaExpression<T>(Guid callerKey)
        {
            string path = string.Empty,
                json = string.Empty;

            using (var stream = File.OpenRead(path))
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            var serializedLambda = Deserialize<LambdaExpression>(json, typeof(T).Assembly);
            return serializedLambda;
        }
    }
}