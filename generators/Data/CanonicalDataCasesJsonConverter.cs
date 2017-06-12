using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Generators.Data
{
    public class CanonicalDataCasesJsonConverter : JsonConverter
    {
        private const string TokensPath = "$..*[?(@.property)]";

        public override bool CanConvert(Type objectType) => typeof(IEnumerable<CanonicalData>).GetTypeInfo().IsAssignableFrom(objectType);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var casesToken = JToken.ReadFrom(reader);
            var caseTokens = casesToken.SelectTokens(TokensPath).ToArray();
            
            return new JArray(caseTokens).ToObject(objectType);            
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}