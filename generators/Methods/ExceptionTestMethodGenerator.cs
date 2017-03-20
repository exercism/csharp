using System;
using System.Collections.Generic;

namespace Generators.Methods
{
    public class ExceptionTestMethodGenerator : TestMethodGenerator
    {
        protected override string Body 
        {
            get
            {
                switch (TestMethodData.Options.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return $"Assert.Throws<{ExceptionType}>(() => {TestedClassName}.{TestedMethod}({Input}));";
                    case TestedMethodType.Instance:
                        return $"var sut = new {TestedClassName}();\n    Assert.Throws<{ExceptionType}>(() => sut.{TestedMethod}({Input}));;";
                    case TestedMethodType.Extension:
                        return $"Assert.Throws<{ExceptionType}>(() => {Input}.{TestedMethod}());";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected override ISet<string> UsingNamespaces => new HashSet<string> { TestMethodData.Options.ExceptionType.Namespace };

        protected virtual string ExceptionType => TestMethodData.Options.ExceptionType.Name;
    }
}