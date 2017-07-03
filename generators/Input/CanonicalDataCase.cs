using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public IDictionary<string, object> Input { get; set; }

        [JsonIgnore]
        public IDictionary<string, object> ConstructorInput { get; set; }

        public object Expected { get; set; }

        [JsonIgnore]
        public IDictionary<string, object> Properties { get; set; }

        [JsonIgnore]
        public bool UseVariablesForInput { get; set; }

        [JsonIgnore]
        public bool UseVariableForExpected { get; set; }

        [JsonIgnore]
        public bool UseVariablesForConstructorParameters { get; set; }

        [JsonIgnore]
        public bool UseVariableForTested { get; set; }

        [JsonIgnore]
        public TestedMethodType TestedMethodType { get; set; } = TestedMethodType.Static;

        [JsonIgnore]
        public Type ExceptionThrown { get; set; }
    }
}