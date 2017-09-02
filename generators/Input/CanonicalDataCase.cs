using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Linq;

namespace Generators.Input
{
    [JsonConverter(typeof(CanonicalDataCaseJsonConverter))]
    public class CanonicalDataCase
    {
        private IDictionary<string, object> _constructorInput;

        [Required]
        public string Description { get; set; }

        [Required]
        public string Property { get; set; }

        [JsonIgnore]
        public IDictionary<string, object> Input { get; set; }

        [JsonIgnore]
        public IDictionary<string, object> ConstructorInput
        {
            get
            {
                return _constructorInput;
            }
            set
            {
                RemoveDuplicateInputEntries(value);
                UpdateInstanceType(value);

                _constructorInput = value;
            }
        }

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
        public TestedMethodType TestedMethodType { get; set; }

        [JsonIgnore]
        public Type ExceptionThrown { get; set; }

        private void RemoveDuplicateInputEntries(IDictionary<string, object> constructorInputDictionary)
        {
            foreach (var key in constructorInputDictionary.Keys)
            {
                if (Input.ContainsKey(key))
                {
                    Input.Remove(key);
                }
            }
        }

        private void UpdateInstanceType(IDictionary<string, object> constructorInputDictionary)
        {
            if (constructorInputDictionary.Keys.Any())
            {
                TestedMethodType = TestedMethodType.Instance;
            }
        }
    }
}