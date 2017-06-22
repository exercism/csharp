using System;
using System.Collections.Generic;
using System.Linq;

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
                        if (UseVariableForExpected)
                            return ExpectedVariableDeclaration.Concat(new[] { $"Assert.Equal(expected, {TestedClassName}.{TestedMethodName}({Input}));" });

                        return new[] { $"Assert.Equal({Expected}, {TestedClassName}.{TestedMethodName}({Input}));" };
                    case TestedMethodType.Instance:
                        if (UseVariableForExpected)
                            return ExpectedVariableDeclaration.Concat(new[] { $"var sut = new {TestedClassName}();", $"Assert.Equal(expected, sut.{TestedMethodName}({Input}));" });

                        return new[] { $"var sut = new {TestedClassName}();", $"Assert.Equal({Expected}, sut.{TestedMethodName}({Input}));" };
                    case TestedMethodType.Extension:
                        if (UseVariableForExpected)
                            return ExpectedVariableDeclaration.Concat(new[] { $"Assert.Equal(expected, {Input}.{TestedMethodName}());" });

                        return new[] { $"Assert.Equal({Expected}, {Input}.{TestedMethodName}());" };
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}