using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Generators
{
    public class CanonicalData
    {
        [Required]
        public string Exercise { get; set; }

        [Required]
        public string Version { get; set; }

        public string[] Comments { get; set; }

        public CanonicalDataCase[] Cases { get; set; }
    }
}