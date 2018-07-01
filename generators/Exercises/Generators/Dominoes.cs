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
            data.Input["dominoes"] = ConvertDominoes(data.Input["dominoes"]);
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(ValueTuple).Namespace);
        }

        private static ValueTuple<int, int>[] ConvertDominoes(dynamic input) 
            => ((JToken)input).ToObject<int[][]>().Select(x => (x[0], x[1])).ToArray();
    }
}
