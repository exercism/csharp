using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Generators.Input
{
    public class CanonicalDataCaseJsonConverter : JsonConverter
    {
        private static readonly string[] NonInputProperties = { "description", "property", "expected", "comments" };

        public override bool CanConvert(Type objectType) => typeof(CanonicalDataCase) == objectType;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jToken = JToken.ReadFrom(reader);

            var canonicalDataCase = new CanonicalDataCase();
            serializer.Populate(new JTokenReader(jToken), canonicalDataCase);
            
            canonicalDataCase.Properties = CanonicalDataCaseJson.ToDictionary(jToken);
            canonicalDataCase.SetInputParameters(GetInputProperties(canonicalDataCase.Properties));
            
            return canonicalDataCase;
        }

        private static string[] GetInputProperties(IDictionary<string, dynamic> properties) => properties.Keys.Except(NonInputProperties).ToArray();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}