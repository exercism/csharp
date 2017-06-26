using System.Collections.Generic;
using System.Linq;

namespace Generators.Output
{
    public class EqualityTestMethodGenerator : TestMethodGenerator
    {
        protected override IEnumerable<string> Body => Variables.Append($"Assert.Equal({ExpectedParameter}, {TestedMethodInvocation});");
    }
}