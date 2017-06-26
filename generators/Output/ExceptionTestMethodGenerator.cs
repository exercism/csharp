using System.Collections.Generic;
using System.Linq;

namespace Generators.Output
{
    public class ExceptionTestMethodGenerator : TestMethodGenerator
    {
        protected override IEnumerable<string> Body => Variables.Append($"Assert.Throws<{ExceptionType}>(() => {TestedMethodInvocation});");
        
        private string ExceptionType => Configuration.ExceptionType.FullName;
    }
}