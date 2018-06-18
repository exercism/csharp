using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;

namespace Generators.Output
{
    public class TestMethodBodyData
    {
        private const string SutVariableName = "sut";
        private const string TestedVariableName = "actual";
        private const string ExpectedVariableName = "expected";

        private readonly TestMethodBody _testMethodBody;

        public TestMethodBodyData(TestMethodBody testMethodBody) => _testMethodBody = testMethodBody;

        public string TestedValue => _testMethodBody.UseVariableForTested ? TestedVariableName : TestedMethodInvocation;
        public string InputParameters => _testMethodBody.UseVariablesForInput ? string.Join(", ", CanonicalDataCase.InputParameters.Select(key => key.ToVariableName())) : ValueFormatter.Format(Input);
        public string ExpectedParameter => _testMethodBody.UseVariableForExpected ? ExpectedVariableName : ValueFormatter.Format(CanonicalDataCase.Expected);
        public string ConstructorParameters => _testMethodBody.UseVariablesForConstructorParameters ? string.Join(", ", CanonicalDataCase.ConstructorInputParameters.Select(key => key.ToVariableName())) : ValueFormatter.Format(ConstructorInput);

        private CanonicalDataCase CanonicalDataCase => _testMethodBody.CanonicalDataCase;

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

                if (_testMethodBody.UseVariablesForInput)
                    lines.AddRange(InputVariablesDeclaration);

                if (_testMethodBody.UseVariablesForConstructorParameters)
                    lines.AddRange(ConstructorVariablesDeclaration);

                if (CanonicalDataCase.TestedMethodType == TestedMethodType.Instance)
                    lines.AddRange(SutVariableDeclaration);

                if (_testMethodBody.UseVariableForTested)
                    lines.AddRange(ActualVariableDeclaration);

                if (_testMethodBody.UseVariableForExpected)
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