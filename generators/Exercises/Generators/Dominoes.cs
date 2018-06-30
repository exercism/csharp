using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
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
            var dominoes = ((JArray)input).Children();
            var tuplesStringLiteral = dominoes.Select(s => s.ToObject<int[]>()).Select(s => $"Tuple.Create({s[0]}, {s[1]})");
            return new UnescapedValue($"new Tuple<int, int>[] {{ {string.Join(", ", tuplesStringLiteral)} }}");
        }
    }
}
