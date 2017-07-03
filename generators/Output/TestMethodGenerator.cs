using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;

namespace Generators.Output
{
    public abstract class TestMethodGenerator
    {
        protected const string SutVariableName = "sut";
        protected const string ExpectedVariableName = "expected";

        public TestMethod Create(CanonicalDataCase canonicalDataCase, Exercise exercise)
        {
            CanonicalDataCase = canonicalDataCase;
            CanonicalData = exercise.CanonicalData;

            return new TestMethod { MethodName = TestMethodName, Body = Body, GeneratedFrom = CanonicalDataCase };
        }

        protected abstract IEnumerable<string> Body { get; }

        protected CanonicalDataCase CanonicalDataCase { get; private set; }
        protected CanonicalData CanonicalData { get; private set; }

        protected string TestMethodName => CanonicalDataCase.Description.ToTestMethodName();
        protected string TestedClassName => CanonicalData.Exercise.ToTestedClassName();
        protected string TestedMethodName => CanonicalDataCase.Property.ToTestedMethodName();

        protected object Input => ValueFormatter.Format(CanonicalDataCase.Input);
        protected object Expected => ValueFormatter.Format(CanonicalDataCase.Expected);
        protected object ConstructorInput => ValueFormatter.Format(CanonicalDataCase.ConstructorInput);

        protected object InputParameters => UseVariablesForInput ? string.Join(", ", CanonicalDataCase.Input.Keys.Select(key => key.ToVariableName())) : Input;
        protected object ExpectedParameter => UseVariableForExpected ? ExpectedVariableName : Expected;
        protected object ConstructorParameters => UseVariablesForConstructor ? string.Join(", ", CanonicalDataCase.ConstructorInput.Keys.Select(key => key.ToVariableName())) : ConstructorInput;

        protected IEnumerable<string> InputVariablesDeclaration => ValueFormatter.FormatVariables(CanonicalDataCase.Input);
        protected IEnumerable<string> ExpectedVariableDeclaration => ValueFormatter.FormatVariable(CanonicalDataCase.Expected, ExpectedVariableName);
        protected IEnumerable<string> ConstructorVariablesDeclaration => ValueFormatter.FormatVariables(CanonicalDataCase.ConstructorInput);
        protected IEnumerable<string> SutVariableDeclaration => new [] {$"var {SutVariableName} = new {TestedClassName}({ConstructorParameters});" };

        protected virtual bool UseVariablesForInput => CanonicalDataCase.UseInputParameters;
        protected virtual bool UseVariablesForConstructor => CanonicalDataCase.UseConstructorParameters;
        protected virtual bool UseVariableForExpected => CanonicalDataCase.UseExpectedParameter;
        
        protected IEnumerable<string> Variables
        {
            get
            {
                var lines = new List<string>();

                if (UseVariablesForInput)
                    lines.AddRange(InputVariablesDeclaration);

                if (UseVariablesForConstructor)
                    lines.AddRange(ConstructorVariablesDeclaration);

                if (CanonicalDataCase.TestedMethodType == TestedMethodType.Instance)
                    lines.AddRange(SutVariableDeclaration);

                if (UseVariableForExpected)
                    lines.AddRange(ExpectedVariableDeclaration);

                return lines;
            }
        }

        protected string TestedMethodInvocation
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