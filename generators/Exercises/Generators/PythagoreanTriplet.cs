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
            namespaces.Add(typeof(HashSet<int>).Namespace);
            namespaces.Add("System.Linq");
        }

        private string RenderAssert(TestMethod testMethod)
        {
            return Render.AssertEqual(
                RenderExpected(testMethod.Expected),
                RenderActual(testMethod.Input["n"]));
        }

        private string RenderActual(dynamic input) => $"Triplet.Where({input}, 1, {input}).ToHashSet()";

        private string RenderExpected(dynamic value)
        {
            var sb = new StringBuilder();
            sb.AppendLine("new Triplet[]{");
            var array = value as JArray;
            foreach (var item in array)
            {
                var input = (item as JArray).ToObject<int[]>();
                sb.AppendLine($"    new Triplet({input[0]}, {input[1]}, {input[2]}),");
            }
            sb.AppendLine("}.ToHashSet()");

            return sb.ToString();
        }
    }
}