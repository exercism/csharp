using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Exercises;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace generators.Exercises.Generators
{
    internal class PythagoreanTriplet : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod) => testMethod.Expected = ConvertExpected(testMethod.Expected);

        protected override void UpdateNamespaces(ISet<string> namespaces) => namespaces.Add(typeof(Array).Namespace);

        private dynamic ConvertExpected(dynamic value)
        {
            int[][] values = value.ToObject<int[][]>();
            var triplets = values.Select(ints => (ints[0], ints[1], ints[2])).ToArray();
            return new UnescapedValue(Render.ArrayMultiLine(triplets));
        }
    }
}