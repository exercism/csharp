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
                switch (Configuration.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return new[] { $"{Assertion}({TestedClassName}.{TestedMethodName}({Input}));" };
                    case TestedMethodType.Instance:
                        return new[] { $"var sut = new {TestedClassName}();", $"{Assertion}(sut.{TestedMethodName}({Input}));" };
                    case TestedMethodType.Extension:
                            return new[] { $"{Assertion}({Input}.{TestedMethodName}());" };
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private string Assertion => $"Assert.{Convert.ToBoolean(CanonicalDataCase.Expected)}";
    }
}