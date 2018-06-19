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

        public CanonicalDataCase CanonicalDataCase { get; }

        public TestMethodBodyData(CanonicalDataCase canonicalDataCase)
        {
            CanonicalDataCase = canonicalDataCase;

            UseVariablesForInput = CanonicalDataCase.UseVariablesForInput;
            UseVariablesForConstructorParameters = CanonicalDataCase.UseVariablesForConstructorParameters;
            UseVariableForExpected = CanonicalDataCase.UseVariableForExpected;
            UseVariableForTested = CanonicalDataCase.UseVariableForTested;
        }

        public bool UseVariablesForInput { get; set; }
        public bool UseVariablesForConstructorParameters { get; set; }
        public bool UseVariableForExpected { get; set; }
        public bool UseVariableForTested { get; set; }

        public string TestedValue => UseVariableForTested ? TestedVariableName : TestedMethodInvocation;
        public string InputParameters => UseVariablesForInput ? string.Join(", ", CanonicalDataCase.InputParameters.Select(key => key.ToVariableName())) : ValueFormatter.Format(Input);
        public string ExpectedParameter => UseVariableForExpected ? ExpectedVariableName : ValueFormatter.Format(CanonicalDataCase.Expected);
        public string ConstructorParameters => UseVariablesForConstructorParameters ? string.Join(", ", CanonicalDataCase.ConstructorInputParameters.Select(key => key.ToVariableName())) : ValueFormatter.Format(ConstructorInput);

        private string TestedClassName => CanonicalDataCase.Exercise.ToTestedClassName();
        private string TestedMethodName => CanonicalDataCase.Property.ToTestedMethodName();

        private IDictionary<string, object> Input => CanonicalDataCase.InputParameters.ToDictionary(key => key, key => CanonicalDataCase.Input[key]);
        private IDictionary<string, object> ConstructorInput => CanonicalDataCase.ConstructorInputParameters.ToDictionary(key => key, key => CanonicalDataCase.Input[key]);
        private object Expected => CanonicalDataCase.Expected;

        private IEnumerable<string> InputVariablesDeclaration => ValueFormatter.FormatVariables(Input);
        private IEnumerable<string> ExpectedVariableDeclaration => ValueFormatter.FormatVariable(Expected, ExpectedVariableName);
        private IEnumerable<string> ConstructorVariablesDeclaration => ValueFormatter.FormatVariables(ConstructorInput);
        private IEnumerable<string> SutVariableDeclaration => new[] { $"var {SutVariableName} = new {TestedClassName}({ConstructorParameters});" };
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

                if (CanonicalDataCase.TestedMethodType == TestedMethodType.Instance)
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
                switch (CanonicalDataCase.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return $"{TestedClassName}.{TestedMethodName}({InputParameters})";
                    case TestedMethodType.Instance:
                        return $"{SutVariableName}.{TestedMethodName}({InputParameters})";
                    case TestedMethodType.Extension:
                        return $"{InputParameters}.{TestedMethodName}()";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}