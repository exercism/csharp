using System.Collections.Generic;
using System.Linq;
using Generators.Input;

namespace Generators.Exercises
{
    public class Etl : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.Input = ConvertInput(canonicalDataCase.Input);
            canonicalDataCase.Expected = ConvertExpected(canonicalDataCase.Expected);
            canonicalDataCase.SetInputParameters("input");
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key, kv => int.Parse($"{kv.Value}"));

        private static IDictionary<string, dynamic> ConvertInput(IDictionary<string, dynamic> input)
            => new Dictionary<string, dynamic>
            {
                ["input"] = input.ToDictionary(kv => int.Parse(kv.Key), kv => (string[])kv.Value)
            };

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Dictionary<string, int>).Namespace };
    }
}
