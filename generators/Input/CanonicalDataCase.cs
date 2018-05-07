using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace Generators.Input
{
    [JsonConverter(typeof(CanonicalDataCaseParser))]
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
        public IDictionary<string, dynamic> Input { get; set; }

        [JsonIgnore]
        public IDictionary<string, dynamic> ConstructorInput { get; set; }

        [JsonIgnore]
        public IDictionary<string, dynamic> Properties { get; set; }

        [JsonIgnore]
        public dynamic Expected { get; set; }

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

            UpdateInput();
        }

        public void SetConstructorInputParameters(params string[] properties)
        {
            _constructorInputParameters.Clear();
            _constructorInputParameters.UnionWith(properties);
            
            _inputParameters.ExceptWith(properties);

            TestedMethodType = TestedMethodType.Instance;

            UpdateInput();
        }

        private void UpdateInput()
        {
            ConstructorInput = _constructorInputParameters.ToDictionary(parameter => parameter, parameter => Input[parameter]);
            Input = _inputParameters.ToDictionary(parameter => parameter, parameter => Input[parameter]);            
        }
    }
}