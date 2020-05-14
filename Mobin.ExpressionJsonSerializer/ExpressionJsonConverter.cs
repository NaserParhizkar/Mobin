using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Mobin.ExpressionJsonSerializer
{
    public class ExpressionJsonConverter : JsonConverter
    {
        private static readonly System.Type TypeOfExpression = typeof(Expression);

        public ExpressionJsonConverter(Assembly resolvingAssembly)
        {
            this._assembly = resolvingAssembly;
        }

        public override bool CanConvert(System.Type objectType)
        {
            return objectType == TypeOfExpression
                || objectType.IsSubclassOf(TypeOfExpression);
        }

        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
        {
            Serializer.Serialize(writer, serializer, (Expression)value);
        }

        public override object ReadJson(
            JsonReader reader, System.Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            var a = Deserializer.Deserialize(
                this._assembly, JToken.ReadFrom(reader)
            );

            return a;
        }

        private readonly Assembly _assembly;
    }
}
