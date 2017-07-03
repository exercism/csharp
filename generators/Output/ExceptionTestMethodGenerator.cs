using System.Collections.Generic;
using System.Linq;

namespace Generators.Output
{
    public class ExceptionTestMethodGenerator : TestMethodGenerator
    {
        protected override IEnumerable<string> Body => Variables.Append($"Assert.Throws<{ExceptionType}>(() => {TestedValue});");

        protected override bool UseVariableForExpected => false;
        protected override bool UseVariableForTested => false;

        private string ExceptionType => CanonicalDataCase.ExceptionThrown.FullName;
    }
}