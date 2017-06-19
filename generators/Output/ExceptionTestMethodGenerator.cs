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
                switch (Configuration.TestedMethodFormat)
                {
                    case TestedMethodFormat.Static:
                        return new[] { $"Assert.Throws<{ExceptionType}>(() => {TestedClassName}.{TestedMethodName}({Input}));" };
                    case TestedMethodFormat.Instance:
                        return new[] { $"var sut = new {TestedClassName}();", $"Assert.Throws<{ExceptionType}>(() => sut.{TestedMethodName}({Input}));;" };
                    case TestedMethodFormat.Extension:
                        return new[] { $"Assert.Throws<{ExceptionType}>(() => {Input}.{TestedMethodName}());" };
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected virtual string ExceptionType => Configuration.ExceptionType.Name;
    }
}