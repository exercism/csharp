using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Generators.Input
{
    public class CanonicalDataCasesJsonConverter : JsonConverter
    {
        private const string TokensPath = "$..*[?(@.property)]";

        public override bool CanConvert(Type objectType) => typeof(CanonicalDataCase[]).GetTypeInfo().IsAssignableFrom(objectType);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var casesToken = JToken.ReadFrom(reader);
            var caseTokens = new JArray(casesToken.SelectTokens(TokensPath));
            var canonicalDataCases = new JArray(caseTokens).ToObject<CanonicalDataCase[]>();
            

            foreach (var groupedCanonicalDataCases in canonicalDataCases.ToLookup(c => c.Property))
            {
                foreach (var groupedProperties in groupedCanonicalDataCases.SelectMany(x => x.Properties).ToLookup(x => x.Key))
                {
                    if (groupedProperties.Any(x => x.Value is string[]))
                    {
                        foreach (var groupedCanonicalDataCase in groupedCanonicalDataCases.Where(x => x.Properties[groupedProperties.Key] is JArray))
                            groupedCanonicalDataCase.Properties[groupedProperties.Key] = new string[0];

                        foreach (var groupedCanonicalDataCase in groupedCanonicalDataCases.Where(x => x.Input.ContainsKey(groupedProperties.Key) && x.Input[groupedProperties.Key] is JArray))
                            groupedCanonicalDataCase.Input[groupedProperties.Key] = new string[0];
                    }
                    else if (groupedProperties.Any(x => x.Value is int[]))
                    {
                        foreach (var groupedCanonicalDataCase in groupedCanonicalDataCases.Where(x => x.Properties[groupedProperties.Key] is JArray))
                            groupedCanonicalDataCase.Properties[groupedProperties.Key] = new int[0];

                        foreach (var groupedCanonicalDataCase in groupedCanonicalDataCases.Where(x => x.Input.ContainsKey(groupedProperties.Key) && x.Input[groupedProperties.Key] is JArray))
                            groupedCanonicalDataCase.Input[groupedProperties.Key] = new int[0];
                    }
                }
            }



            return canonicalDataCases;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();


    }
}