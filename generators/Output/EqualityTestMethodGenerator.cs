using System;
using System.Collections.Generic;

namespace Generators.Output
{
    public class EqualityTestMethodGenerator : TestMethodGenerator
    {
        protected override IEnumerable<string> Body 
        {
            get
            {
                switch (Configuration.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return new[] { $"Assert.Equal({Expected}, {TestedClassName}.{TestedMethodName}({Input}));" };
                    case TestedMethodType.Instance:
                        return new[] { $"var sut = new {TestedClassName}();", $"Assert.Equal({Expected}, sut.{TestedMethodName}({Input}));" };
                    case TestedMethodType.Extension:
                        return new[] { $"Assert.Equal({Expected}, {Input}.{TestedMethodName}());" };
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

    }
}