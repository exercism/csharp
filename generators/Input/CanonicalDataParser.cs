using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Generators.Input
{
    public static class CanonicalDataParser
    {
        public static CanonicalData Parse(string exercise)
        {
            var canonicalDataJson = CanonicalDataFile.Contents(exercise);
            var canonicalData = JsonConvert.DeserializeObject<CanonicalData>(canonicalDataJson);
            
            Validator.ValidateObject(canonicalData, new ValidationContext(canonicalData));

            return canonicalData;
        }
    }
}