using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace Generators.Input
{
    [JsonConverter(typeof(CanonicalDataCaseJsonConverter))]
    public class CanonicalDataCase
    {
        private readonly HashSet<string> _inputParameters = new HashSet<string>();
        private readonly HashSet<string> _constructorInputParameters = new HashSet<string>();

        [Required]
        public string Property { get; set; }

        [Required]
        public string Description { get; set; }

        [JsonIgnore]
        public string[] DescriptionPath { get; set; }

        [JsonIgnore]
        public IReadOnlyDictionary<string, dynamic> Input
            => _inputParameters.ToDictionary(parameter => parameter, parameter => Properties[parameter]);

        [JsonIgnore]
        public IReadOnlyDictionary<string, dynamic> ConstructorInput 
            => _constructorInputParameters.ToDictionary(parameter => parameter, parameter => Properties[parameter]);

        [JsonIgnore]
        public IDictionary<string, dynamic> Properties { get; set; }

        [JsonIgnore]
        public dynamic Expected
        {
            get => Properties["expected"];
            set => Properties["expected"] = value;
        }

        [JsonIgnore]
        public bool UseVariablesForInput { get; set; }

        [JsonIgnore]
        public bool UseVariableForExpected { get; set; }

        [JsonIgnore]
        public bool UseVariablesForConstructorParameters { get; set; }

        [JsonIgnore]
        public bool UseVariableForTested { get; set; }

        [JsonIgnore]
        public bool UseFullDescriptionPath { get; set; }

        [JsonIgnore]
        public TestedMethodType TestedMethodType { get; set; }

        [JsonIgnore]
        public Type ExceptionThrown { get; set; }

        public void SetInputParameters(params string[] properties)
        {
            _inputParameters.Clear();
            _inputParameters.UnionWith(properties);

            _constructorInputParameters.ExceptWith(properties);
        }

        public void SetConstructorInputParameters(params string[] properties)
        {
            _constructorInputParameters.Clear();
            _constructorInputParameters.UnionWith(properties);
            
            _inputParameters.ExceptWith(properties);

            TestedMethodType = TestedMethodType.Instance;
        }
    }
}