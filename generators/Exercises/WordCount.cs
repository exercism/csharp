using Generators.Input;
using System.Collections.Generic;
using System.Linq;

namespace Generators.Exercises
{
    public class WordCount : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.UseVariableForTested = true;
            canonicalDataCase.Expected = ConvertExpected(canonicalDataCase.Expected);
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key, kv => int.Parse(kv.Value.ToString()));

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Dictionary<string, int>).Namespace };
    }
}
