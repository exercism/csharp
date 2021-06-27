using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Dominoes : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.Input["dominoes"] = ConvertDominoes(testMethod.Input["dominoes"]);
        }

        private static ValueTuple<int, int>[] ConvertDominoes(JToken input)
            => input.ToObject<int[][]>()!.Select(x => (x[0], x[1])).ToArray();

        protected override void UpdateNamespaces(ISet<string> namespaces) => namespaces.Add(typeof(ValueTuple).Namespace!);
    }
}
