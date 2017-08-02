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

        public TestMethodBodyData(TestMethodBody testMethodBody)
        {
            _testMethodBody = testMethodBody;
        }

        public object TestedValue => _testMethodBody.UseVariableForTested ? TestedVariableName : TestedMethodInvocation;
        public object InputParameters => _testMethodBody.UseVariablesForInput ? string.Join(", ", CanonicalDataCase.Input.Keys.Select(key => NameExtensions.ToVariableName(key))) : Input;
        public object ExpectedParameter => _testMethodBody.UseVariableForExpected ? ExpectedVariableName : Expected;
        public object ConstructorParameters => _testMethodBody.UseVariablesForConstructorParameters ? string.Join(", ", CanonicalDataCase.ConstructorInput.Keys.Select(key => key.ToVariableName())) : ConstructorInput;

        private CanonicalDataCase CanonicalDataCase => _testMethodBody.CanonicalDataCase;
        private CanonicalData CanonicalData => _testMethodBody.CanonicalData;

        private string TestedClassName => CanonicalData.Exercise.ToTestedClassName();
        private string TestedMethodName => CanonicalDataCase.Property.ToTestedMethodName();

        private object Input => ValueFormatter.Format(CanonicalDataCase.Input);
        private object Expected => ValueFormatter.Format(CanonicalDataCase.Expected);
        private object ConstructorInput => ValueFormatter.Format(CanonicalDataCase.ConstructorInput);

        private IEnumerable<string> InputVariablesDeclaration => ValueFormatter.FormatVariables(CanonicalDataCase.Input);
        private IEnumerable<string> ExpectedVariableDeclaration => ValueFormatter.FormatVariable(CanonicalDataCase.Expected, ExpectedVariableName);
        private IEnumerable<string> ConstructorVariablesDeclaration => ValueFormatter.FormatVariables(CanonicalDataCase.ConstructorInput);
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