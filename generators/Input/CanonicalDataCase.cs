﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Generators.Input
{
    [JsonConverter(typeof(CanonicalDataCaseJsonConverter))]
    public class CanonicalDataCase
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Property { get; set; }

        [JsonIgnore]
        public object Input { get; set; }

        public object Expected { get; set; }
    }
}