using System.Collections;
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
                if (ExpectedIsEmptyEnumerable)
                    return Variables.Append($"Assert.Empty({TestedValue});");

                return Variables.Append($"Assert.Equal({ExpectedParameter}, {TestedValue});");
            }
        }

        protected override bool UseVariableForExpected => base.UseVariableForExpected && !ExpectedIsEmptyEnumerable;

        private bool ExpectedIsEmptyEnumerable =>
            !(CanonicalDataCase.Expected is string) &&
            CanonicalDataCase.Expected is IEnumerable enumerable 
            && enumerable.GetEnumerator().MoveNext() == false;
    }
}