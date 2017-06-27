using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Generators.Input
{
    public class CanonicalDataCaseJsonConverter : JsonConverter
    {
        private static readonly string[] NonInputProperties = {"description", "property", "expected", "comments"};

        public override bool CanConvert(Type objectType) => typeof(CanonicalDataCase) == objectType;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jToken = JToken.ReadFrom(reader);

            var canonicalDataCase = new CanonicalDataCase();
            serializer.Populate(new JTokenReader(jToken), canonicalDataCase);

            canonicalDataCase.Input = GetInputProperty(jToken);

            return canonicalDataCase;
        }

        private static object GetInputProperty(JToken jToken)
        {
            var allProperties = jToken.ToObject<IDictionary<string, object>>();

            foreach (var nonInputProperty in NonInputProperties)
                allProperties.Remove(nonInputProperty);

            if (allProperties.Keys.Count == 1)
                return allProperties[allProperties.Keys.First()];

            return allProperties;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}