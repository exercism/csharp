using System;
using System.Collections.Generic;

namespace Generators.Methods
{
    public class ExceptionTestMethodGenerator : TestMethodGenerator
    {
        protected override IEnumerable<string> Body 
        {
            get
            {
                switch (TestMethodData.Options.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return new[] { $"Assert.Throws<{ExceptionType}>(() => {TestedClassName}.{TestedMethod}({Input}));" };
                    case TestedMethodType.Instance:
                        return new[] { $"var sut = new {TestedClassName}();", "Assert.Throws<{ExceptionType}>(() => sut.{TestedMethod}({Input}));;" };
                    case TestedMethodType.Extension:
                        return new[] { $"Assert.Throws<{ExceptionType}>(() => {Input}.{TestedMethod}());" };
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected override ISet<string> UsingNamespaces => new HashSet<string> { TestMethodData.Options.ExceptionType.Namespace };

        protected virtual string ExceptionType => TestMethodData.Options.ExceptionType.Name;
    }
}