using System;
using System.Collections.Generic;
using Generators.Helpers;

namespace Generators.Methods
{
    public class BooleanTestMethodGenerator : TestMethodGenerator
    {
        protected override IEnumerable<string> Body
        {
            get
            {
                switch (TestMethodData.Options.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return new[] { $"{Assertion}({TestedClassName}.{TestedMethod}({Input}));" };
                    case TestedMethodType.Instance:
                        return new[] { $"var sut = new {TestedClassName}();\n{Tab}{Assertion}(sut.{TestedMethod}({Input}));" };
                    case TestedMethodType.Extension:
                            return new[] { $"{Assertion}({Input}.{TestedMethod}());" };
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