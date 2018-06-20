using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;

namespace Generators.Output
{
    public sealed class TestMethodBodyData
    {
        private const string SutVariableName = "sut";
        private const string TestedVariableName = "actual";
        private const string ExpectedVariableName = "expected";

        public TestMethodBodyData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
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
        
        public string TestedValue => UseVariableForTested ? TestedVariableName : TestedMethodInvocation;
        public string _inputParameters => UseVariablesForInput ? string.Join(", ", InputParameters.Select(key => key.ToVariableName())) : ValueFormatter.Format(_input);
        public string ExpectedParameter => UseVariableForExpected ? ExpectedVariableName : ValueFormatter.Format(Expected);
        public string _constructorParameters => UseVariablesForConstructorParameters ? string.Join(", ", ConstructorInputParameters.Select(key => key.ToVariableName())) : ValueFormatter.Format(_constructorInput);

        private string TestedClassName => Exercise.ToTestedClassName();
        private string TestedMethodName => Property.ToTestedMethodName();

        private IDictionary<string, object> _input => InputParameters.ToDictionary(key => key, key => Input[key]);
        private IDictionary<string, object> _constructorInput => ConstructorInputParameters.ToDictionary(key => key, key => Input[key]);
        
        private IEnumerable<string> InputVariablesDeclaration => ValueFormatter.FormatVariables(_input);
        private IEnumerable<string> ExpectedVariableDeclaration => ValueFormatter.FormatVariable(Expected, ExpectedVariableName);
        private IEnumerable<string> ConstructorVariablesDeclaration => ValueFormatter.FormatVariables(_constructorInput);
        private IEnumerable<string> SutVariableDeclaration => new[] { $"var {SutVariableName} = new {TestedClassName}({_constructorParameters});" };
        private IEnumerable<string> ActualVariableDeclaration => new[] { $"var {TestedVariableName} = {TestedMethodInvocation};" };

        public IEnumerable<string> Variables
        {
            get
            {
                var lines = new List<string>();

                if (UseVariablesForInput)
                    lines.AddRange(InputVariablesDeclaration);

                if (UseVariablesForConstructorParameters)
                    lines.AddRange(ConstructorVariablesDeclaration);

                if (TestedMethodType == TestedMethodType.Instance)
                    lines.AddRange(SutVariableDeclaration);

                if (UseVariableForTested)
                    lines.AddRange(ActualVariableDeclaration);

                if (UseVariableForExpected)
                    lines.AddRange(ExpectedVariableDeclaration);

                return lines;
            }
        }

        public string TestedMethodInvocation
        {
            get
            {
                switch (TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return $"{TestedClassName}.{TestedMethodName}({_inputParameters})";
                    case TestedMethodType.Instance:
                        return $"{SutVariableName}.{TestedMethodName}({_inputParameters})";
                    case TestedMethodType.Extension:
                        return $"{_inputParameters}.{TestedMethodName}()";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}