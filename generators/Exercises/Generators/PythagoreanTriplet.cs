using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Exercises;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace generators.Exercises.Generators
{
    public class PythagoreanTriplet : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Assert = RenderAssert(testMethod);
        }
        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }

        private string RenderAssert(TestMethod testMethod)
        {
            return Render.AssertEqual(
                RenderExpected(testMethod.Expected)
                , RenderActual(testMethod.Input["n"]));
        }

        private string RenderActual(dynamic input) => $"PythagoreanTriplet.TripletsWithSum({input})";

        private string RenderExpected(dynamic value)
        {
            var array = value as JArray;
            var expected = new List<(int, int, int)>();
            foreach (var item in array)
            {
                var input = (item as JArray).ToObject<int[]>();
                expected.Add((input[0], input[1], input[2]));
            }
            return Render.ArrayMultiLine(expected.ToArray());
        }
    }
}