using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Generators.Input
{
    public class CanonicalDataParser
    {
        private readonly CanonicalDataFile _canonicalDataFile;

        public CanonicalDataParser(CanonicalDataOptions options)
        {
            _canonicalDataFile = new CanonicalDataFile(options);
            _canonicalDataFile.DownloadData();
        }

        public CanonicalData Parse(Exercise exercise)
        {
            var canonicalDataJson = _canonicalDataFile.Contents(exercise.Name);
            var canonicalData = JsonConvert.DeserializeObject<CanonicalData>(canonicalDataJson);
            
            Validator.ValidateObject(canonicalData, new ValidationContext(canonicalData));

            return canonicalData;
        }
    }
}