using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Exercises;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Input;

namespace Exercism.CSharp.Output
{
    internal class TestMethod
    {
        private readonly HashSet<string> _inputParameters = new(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<string> _constructorInputParameters = new(StringComparer.OrdinalIgnoreCase);
        
        public TestMethod(Exercise exercise, TestCase testCase)
        {
            Input = new Dictionary<string, dynamic>(testCase.Input, StringComparer.OrdinalIgnoreCase);
            Expected = testCase.Expected;
            Property = testCase.Property;
            Description = testCase.Description;
            TestMethodName = testCase.Description.ToTestMethodName();
            TestMethodNameWithPath = string.Join(" - ", testCase.DescriptionPath).ToTestMethodName();
            TestedClass = exercise.Name.ToTestedClassName();
            TestedMethod = testCase.Property.ToTestedMethodName();
            Skip = testCase.Index > 0;

            InputParameters = testCase.Input.Keys.ToArray();
        }
        
        public string? Act { get; set; }
        public string? Arrange { get; set; }
        public string? Assert { get; set; }

        public IDictionary<string, dynamic> Input { get; }
        public dynamic? Expected { get; set; }
        public string Property { get; }
        public string Description { get; }
        public bool Skip { get; set; }

        public bool UseVariablesForInput { get; set; }
        public bool UseVariableForExpected { get; set; }
        public bool UseVariablesForConstructorParameters { get; set; }
        public bool UseVariableForTested { get; set; }
        public bool UseVariableForSut => TestedMethodType is TestedMethodType.InstanceMethod or TestedMethodType.Property;

        public string TestMethodName { get; set; }
        public string TestMethodNameWithPath { get; }
        public string TestedClass { get; set; }
        public string TestedMethod { get; set; }
        public TestedMethodType TestedMethodType { get; set; }
        public Type? ExceptionThrown { get; set; }
        public bool ExpectedIsError => Expected is Dictionary<string, object> dict && dict.ContainsKey("error");
        
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