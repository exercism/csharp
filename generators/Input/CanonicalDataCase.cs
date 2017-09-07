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
        public IDictionary<string, dynamic> Input { get; set; }

        [JsonIgnore]
        public IDictionary<string, dynamic> ConstructorInput { get; set; }

        [JsonIgnore]
        public dynamic Expected
        {
            get => Properties["expected"];
            set => Properties["expected"] = value;
        }

        [JsonIgnore]
        public IDictionary<string, dynamic> Properties { get; set; }

        [JsonIgnore]
        public bool UseVariablesForInput { get; set; }

        [JsonIgnore]
        public bool UseVariableForExpected { get; set; }

        [JsonIgnore]
        public bool UseVariablesForConstructorParameters { get; set; }

        [JsonIgnore]
        public bool UseVariableForTested { get; set; }

        [JsonIgnore]
        public TestedMethodType TestedMethodType { get; set; }

        [JsonIgnore]
        public Type ExceptionThrown { get; set; }

        public void AddConstructorParameter(string parameterName)
        {
            ConstructorInput[parameterName] = Properties[parameterName];

            if (Input.ContainsKey(parameterName))
                Input.Remove(parameterName);

            TestedMethodType = TestedMethodType.Instance;
        }
    }
}