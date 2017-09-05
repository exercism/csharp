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

            canonicalDataCase.Properties = jToken.ToObject<IDictionary<string, object>>();
            canonicalDataCase.Input = GetInputProperty(jToken);
            canonicalDataCase.ConstructorInput = new Dictionary<string, object>();

            NormalizeJsonValues(canonicalDataCase.Properties);
            NormalizeJsonValues(canonicalDataCase.Input);

            return canonicalDataCase;
        }

        private static void NormalizeJsonValues(IDictionary<string, object> properties)
        {
            for (var i = 0; i < properties.Count; i++)
            {
                var key = properties.Keys.ElementAt(i);

                if (properties[key] is JArray jArray)
                {
                    // We can't determine the type of the array if the array is empty
                    if (!jArray.Any())
                        continue;

                    switch (jArray[0].Type)
                    {
                        case JTokenType.Object:
                            // TODO
                            break;
                        case JTokenType.Array:
                            // TODO
                            break;
                        case JTokenType.Integer:
                            properties[key] = jArray.ToObject<int[]>();
                            break;
                        case JTokenType.Float:
                            properties[key] = jArray.ToObject<float[]>();
                            break;
                        case JTokenType.String:
                            properties[key] = jArray.ToObject<string[]>();
                            break;
                        case JTokenType.Boolean:
                            properties[key] = jArray.ToObject<bool[]>();
                            break;
                        case JTokenType.Date:
                            properties[key] = jArray.ToObject<DateTime[]>();
                            break;
                        case JTokenType.Bytes:
                            properties[key] = jArray.ToObject<byte[]>();
                            break;
                        case JTokenType.Guid:
                            properties[key] = jArray.ToObject<Guid[]>();
                            break;
                        case JTokenType.Uri:
                            properties[key] = jArray.ToObject<Uri[]>();
                            break;
                        case JTokenType.TimeSpan:
                            properties[key] = jArray.ToObject<TimeSpan[]>();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        private static IDictionary<string, object> GetInputProperty(JToken jToken)
        {
            var allProperties = jToken.ToObject<IDictionary<string, object>>();

            foreach (var nonInputProperty in NonInputProperties)
                allProperties.Remove(nonInputProperty);

            return allProperties;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}