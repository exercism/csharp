using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;

namespace Generators.Exercises
{
    public class Alphametics : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.UseVariableForTested = true;

            if (canonicalDataCase.Expected == null)
                canonicalDataCase.ExceptionThrown = typeof(ArgumentException);
            else
                canonicalDataCase.Expected = ConvertExpected(canonicalDataCase);
        }

        private static dynamic ConvertExpected(CanonicalDataCase canonicalDataCase)
        {
            Dictionary<string, object> expected = canonicalDataCase.Expected;
            return expected.ToDictionary(kv => kv.Key[0], kv => int.Parse(kv.Value.ToString()));
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Dictionary<char, int>).Namespace };
    }
}