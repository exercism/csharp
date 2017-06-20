using System;
using System.Collections.Generic;

namespace Generators.Output
{
    public class ExceptionTestMethodGenerator : TestMethodGenerator
    {
        protected override IEnumerable<string> Body 
        {
            get
            {
                switch (Configuration.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return new[] { $"Assert.Throws<{ExceptionType}>(() => {TestedClassName}.{TestedMethodName}({Input}));" };
                    case TestedMethodType.Instance:
                        return new[] { $"var sut = new {TestedClassName}();", $"Assert.Throws<{ExceptionType}>(() => sut.{TestedMethodName}({Input}));" };
                    case TestedMethodType.Extension:
                        return new[] { $"Assert.Throws<{ExceptionType}>(() => {Input}.{TestedMethodName}());" };
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected virtual string ExceptionType => Configuration.ExceptionType.FullName;
    }
}