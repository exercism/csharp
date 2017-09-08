using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Generators.Input
{
    public static class CanonicalDataCaseJson
    {
        public static IDictionary<string, dynamic> ToDictionary(JToken jToken)
        {
            var properties = jToken.ToObject<IDictionary<string, dynamic>>();

            for (var i = 0; i < properties.Count; i++)
            {
                var key = properties.Keys.ElementAt(i);

                if (properties[key] is JArray jArray)
                {
                    // We can't determine the type of the array if the array is empty
                    if (!jArray.Any())
                        continue;

                    // We can only convert when all values have the same type
                    if (jArray.Select(x => x.Type).Distinct().Count() != 1)
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

            return properties;
        }
    }
}
