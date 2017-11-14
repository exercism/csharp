using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Generators.Input
{
    public class CanonicalDataParser
    {
        private readonly CanonicalDataFile _canonicalDataFile;

        public CanonicalDataParser(CanonicalDataFile canonicalDataFile)
        {
            _canonicalDataFile = canonicalDataFile;
        }
        
        public CanonicalData Parse(string exercise)
        {
            var canonicalDataJson = _canonicalDataFile.Contents(exercise);
            var canonicalData = JsonConvert.DeserializeObject<CanonicalData>(canonicalDataJson);
            
            Validator.ValidateObject(canonicalData, new ValidationContext(canonicalData));

            return canonicalData;
        }
    }
}