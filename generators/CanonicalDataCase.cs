using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Generators
{
    [JsonConverter(typeof(CanonicalDataCaseJsonConverter))]
    public class CanonicalDataCase
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Property { get; set; }

        public string[] Comments { get; set; }

        public object Input { get; set; }

        public object Expected { get; set; }

        public IDictionary<string, object> Data { get; set; }
    }
}