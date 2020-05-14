using Newtonsoft.Json;

namespace Kendo.Mvc.Infrastructure
{
    public class DefaultJavaScriptSerializer : IJavaScriptSerializer
    {
        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}