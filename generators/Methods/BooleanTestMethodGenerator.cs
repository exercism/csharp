using System;
using Generators.Helpers;

namespace Generators.Methods
{
    public class BooleanTestMethodGenerator : TestMethodGenerator
    {
        protected override string Body
        {
            get
            {
                switch (TestMethodData.Options.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return $"{Assertion}({TestedClassName}.{TestedMethod}({Input}));";
                    case TestedMethodType.Instance:
                        return $"var sut = new {TestedClassName}();\n    {Assertion}(sut.{TestedMethod}({Input}));";
                    case TestedMethodType.Extension:
                        return $"{Assertion}({Input}.{TestedMethod}());";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private string Assertion
            => $"Assert.{Convert.ToBoolean(TestMethodData.CanonicalDataCase.Expected)}";

        protected override string TestedMethod
            => base.TestedMethod.EnsureStartsWith("Is");
    }
}