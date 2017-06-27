using System;
using System.Collections.Generic;
using Generators.Input;

namespace Generators.Output
{
    public abstract class TestMethodGenerator
    {
        protected const string SutVariableName = "sut";
        protected const string InputVariableName = "input";
        protected const string ExpectedVariableName = "expected";

        public TestMethod Create(CanonicalDataCase canonicalDataCase, Exercise exercise)
        {
            CanonicalDataCase = canonicalDataCase;
            CanonicalData = exercise.CanonicalData;
            Configuration = exercise.Configuration;

            return new TestMethod { MethodName = TestMethodName, Body = Body };
        }

        protected abstract IEnumerable<string> Body { get; }

        protected CanonicalDataCase CanonicalDataCase { get; private set; }
        protected CanonicalData CanonicalData { get; private set; }
        protected ExerciseConfiguration Configuration { get; private set; }

        protected string TestMethodName => CanonicalDataCase.Description.ToTestMethodName();
        protected string TestedClassName => CanonicalData.Exercise.ToTestedClassName();
        protected string TestedMethodName => CanonicalDataCase.Property.ToTestedMethodName();

        protected object Input => ValueFormatter.Format(CanonicalDataCase.Input);
        protected object Expected => ValueFormatter.Format(CanonicalDataCase.Expected);

        protected object ExpectedParameter => UseVariableForExpected ? ExpectedVariableName : Expected;
        protected object InputParameter => UseVariableForInput ? InputVariableName : Input;

        protected IEnumerable<string> InputVariableDeclaration => ValueFormatter.FormatVariable(CanonicalDataCase.Input, InputVariableName);
        protected IEnumerable<string> ExpectedVariableDeclaration => ValueFormatter.FormatVariable(CanonicalDataCase.Expected, ExpectedVariableName);
        protected IEnumerable<string> SutVariableDeclaration => new [] {$"var {SutVariableName} = new {TestedClassName}();" };

        protected bool UseVariableForInput => CanonicalDataCase.Input is MultiLineString;
        protected bool UseVariableForExpected => CanonicalDataCase.Expected is MultiLineString;
        
        protected IEnumerable<string> Variables
        {
            get
            {
                var lines = new List<string>();

                if (UseVariableForInput)
                    lines.AddRange(InputVariableDeclaration);

                if (UseVariableForExpected)
                    lines.AddRange(ExpectedVariableDeclaration);

                if (Configuration.TestedMethodType == TestedMethodType.Instance)
                    lines.AddRange(SutVariableDeclaration);

                return lines;
            }
        }

        protected string TestedMethodInvocation
        {
            get
            {
                switch (Configuration.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return $"{TestedClassName}.{TestedMethodName}({InputParameter})";
                    case TestedMethodType.Instance:
                        return $"{SutVariableName}.{TestedMethodName}({InputParameter})";
                    case TestedMethodType.Extension:
                        return $"{InputParameter}.{TestedMethodName}()";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}