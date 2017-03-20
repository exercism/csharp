using System.Collections.Generic;

namespace Generators.Methods
{
    public class ExceptionTestMethodGenerator : TestMethodGenerator
    {
        protected override string Body 
            => $"Assert.Throws<{TestMethodData.Options.ExceptionType.Name}>(() => {TestedClassName}.{TestedMethod}({Input}));";

        protected override ISet<string> UsingNamespaces => new HashSet<string> { TestMethodData.Options.ExceptionType.Namespace };
    }
}