using System;
using System.Collections.Generic;

namespace Generators.Output
{
    public class BooleanTestMethodGenerator : TestMethodGenerator
    {
        protected override IEnumerable<string> Body
        {
            get
            {
                switch (TestMethodData.Options.TestedMethodFormat)
                {
                    case TestedMethodFormat.Static:
                        return new[] { $"{Assertion}({TestedClassName}.{TestedMethodName}({Input}));" };
                    case TestedMethodFormat.Instance:
                        return new[] { $"var sut = new {TestedClassName}();", $"{Assertion}(sut.{TestedMethodName}({Input}));" };
                    case TestedMethodFormat.Extension:
                            return new[] { $"{Assertion}({Input}.{TestedMethodName}());" };
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private string Assertion => $"Assert.{Convert.ToBoolean(TestMethodData.CanonicalDataCase.Expected)}";
    }
}