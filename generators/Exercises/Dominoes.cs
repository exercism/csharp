using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Dominoes : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.Input["dominoes"] = ConvertInput(data.Input["dominoes"]);
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Tuple).Namespace);
        }

        private static UnescapedValue ConvertInput(dynamic input)
        {
            var dominoes = (input as JArray).Children();

            // Manually format array of ints to array of tuples since the ValueFormatter doesn't handle Tuple<int,int>[]
            // Project each jtoken element to an int array, then format to a string that will create a tuple from the 2-element array (via UnescapedValues)
            var tuplesStringLiteral = dominoes.Select(s => s.ToObject<int[]>()).Select(s => $"Tuple.Create({s[0]}, {s[1]})");
            return new UnescapedValue($"new Tuple<int, int>[] {{ {string.Join(", ", tuplesStringLiteral)} }}");
        }
    }
}
