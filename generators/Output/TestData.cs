using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;

namespace Generators.Output
{
    public sealed class TestData
    {
        public TestData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
        {
            Properties = new Dictionary<string, dynamic>(canonicalDataCase.Properties);
            Input = new Dictionary<string, dynamic>(canonicalDataCase.Input);
            Expected = canonicalDataCase.Expected;

            Exercise = canonicalData.Exercise;
            Property = canonicalDataCase.Property;
            Description = canonicalDataCase.Description;
            DescriptionPath = new List<string>(canonicalDataCase.DescriptionPath);
            
            SetInputParameters(canonicalDataCase.Input.Keys.ToArray());
        }
        
        public IDictionary<string, dynamic> Properties { get; set; }
        public IDictionary<string, dynamic> Input { get; set; }
        public dynamic Expected { get; set; }

        public string Exercise { get; set; }
        public string Property { get; set; }
        public string Description { get; set; }
        public IList<string> DescriptionPath { get; set; }

        public bool UseVariablesForInput { get; set; }
        public bool UseVariableForExpected { get; set; }
        public bool UseVariablesForConstructorParameters { get; set; }
        public bool UseVariableForTested { get; set; }
        public bool UseFullDescriptionPath { get; set; }

        public TestedMethodType TestedMethodType { get; set; }
        public Type ExceptionThrown { get; set; }

        public HashSet<string> InputParameters { get; } = new HashSet<string>();
        public HashSet<string> ConstructorInputParameters { get; } = new HashSet<string>();

        public void SetInputParameters(params string[] properties)
        {
            InputParameters.Clear();
            InputParameters.UnionWith(properties);

            ConstructorInputParameters.ExceptWith(properties);
        }

        public void SetConstructorInputParameters(params string[] properties)
        {
            ConstructorInputParameters.Clear();
            ConstructorInputParameters.UnionWith(properties);

            InputParameters.ExceptWith(properties);

            TestedMethodType = TestedMethodType.Instance;
        }

        public string TestedClassName => Exercise.ToTestedClassName();
        public string TestedMethodName => Property.ToTestedMethodName();
    }
}