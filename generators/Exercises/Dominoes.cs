using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Dominoes : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.Properties["input"] = ConvertInput(canonicalDataCase.Properties["input"]);
            }
        }
        
        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string>() { typeof(Tuple).Namespace };

        private UnescapedValue ConvertInput(dynamic input)
        {
            var dominoes = (input as JArray).Children();

            // Manually format array of ints to array of tuples since the ValueFormatter doesn't handle Tuple<int,int>[]
            // Project each jtoken element to an int array, then format to a string that will create a tuple from the 2-element array (via UnescapedValues)
            var tuplesStringLiteral = dominoes.Select(s => s.ToObject<int[]>()).Select(s => $"Tuple.Create({s[0]}, {s[1]})");
            return new UnescapedValue($"new Tuple<int, int>[] {{ {string.Join(", ", tuplesStringLiteral)} }}");
        }
    }
}
