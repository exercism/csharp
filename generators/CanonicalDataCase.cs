using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Generators
{
    public class CanonicalDataCase
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Property { get; set; }

        public string[] Comments { get; set; }

        public object Expected { get; set; }
    }
}