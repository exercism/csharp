using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Exercises;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Input;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Output
{
    public class TestMethod
    {
        private readonly HashSet<string> _inputParameters = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<string> _constructorInputParameters = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        
        public TestMethod(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
        {
            Input = new Dictionary<string, dynamic>(canonicalDataCase.Input, StringComparer.OrdinalIgnoreCase);
            Expected = canonicalDataCase.Expected;
            Property = canonicalDataCase.Property;
            TestMethodName = canonicalDataCase.Description.ToTestMethodName();
            TestMethodNameWithPath = string.Join(" - ", canonicalDataCase.DescriptionPath).ToTestMethodName();
            TestedClass = canonicalData.Exercise.ToTestedClassName();
            TestedMethod = canonicalDataCase.Property.ToTestedMethodName();
            Skip = canonicalDataCase.Index > 0;

            InputParameters = canonicalDataCase.Input.Keys.ToArray();
        }
        
        public string Act { get; set; }
        public string Arrange { get; set; }
        public string Assert { get; set; }

        public IDictionary<string, dynamic> Input { get; }
        public dynamic Expected { get; set; }
        public string Property { get; }
        public bool Skip { get; set; }

        public bool UseVariablesForInput { get; set; }
        public bool UseVariableForExpected { get; set; }
        public bool UseVariablesForConstructorParameters { get; set; }
        public bool UseVariableForTested { get; set; }
        public bool UseVariableForSut 
            => TestedMethodType == TestedMethodType.InstanceMethod || 
               TestedMethodType == TestedMethodType.Property;

        public string TestMethodName { get; set; }
        public string TestMethodNameWithPath { get; }
        public string TestedClass { get; set; }
        public string TestedMethod { get; set; }
        public TestedMethodType TestedMethodType { get; set; }
        public Type ExceptionThrown { get; set; }
        
        public IReadOnlyCollection<string> InputParameters
        {
            get => _inputParameters;
            set
            {
                _inputParameters.Clear();
                _inputParameters.UnionWith(value);

                _constructorInputParameters.ExceptWith(value);
            }
        }
        
        public IReadOnlyCollection<string> ConstructorInputParameters
        {
            get => _constructorInputParameters;
            set
            {
                _constructorInputParameters.Clear();
                _constructorInputParameters.UnionWith(value);

                _inputParameters.ExceptWith(value);
            }
        }
    }
}