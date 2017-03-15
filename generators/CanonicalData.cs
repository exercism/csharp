using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Generators
{
    public class CanonicalData
    {
        [Required]
        public string Exercise { get; set; }

        [Required]
        public string Version { get; set; }

        public string[] Comments { get; set; }
        
        [JsonConverter(typeof(CanonicalDataCasesJsonConverter))]
        public CanonicalDataCase[] Cases { get; set; }
    }
}