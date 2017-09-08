using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Generators.Input
{
    public class CanonicalDataCasesJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => typeof(CanonicalDataCase[]).GetTypeInfo().IsAssignableFrom(objectType);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) 
            => CanonicalDataCasesJson.ToArray(JToken.ReadFrom(reader));

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}