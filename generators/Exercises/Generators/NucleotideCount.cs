using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class NucleotideCount : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (((Dictionary<string, object>)data.Expected).ContainsKey("error"))
                return;

            data.UseVariableForExpected = true;
            data.SetConstructorInputParameters("strand");
            data.Expected = ConvertExpected(data.Expected);
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key[0], kv => int.Parse($"{kv.Value}"));

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Dictionary<char, int>).Namespace);
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private string RenderAssert(TestMethod method) 
            => method.Data.UseVariableForExpected
                ? RenderEqualAssert(method)
                : RenderThrowsAssert(method);

        private string RenderEqualAssert(TestMethod method) 
            => Render.AssertEqual("expected", $"sut.{method.Data.TestedMethod}");

        private string RenderThrowsAssert(TestMethod method)
        {
            var strand = Render.Object(method.Data.Input["strand"]);
            return Render.AssertThrows<ArgumentException>($"new NucleotideCount({strand})");
        }
    }
}
