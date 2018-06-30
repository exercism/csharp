using System;
using System.Linq;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class PalindromeProducts : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Expected.ContainsKey("error"))
            {
                data.ExceptionThrown = typeof(ArgumentException);
            }
            else
            {
                data.UseVariableForTested = true;
                data.UseVariableForExpected = true;
                data.Expected = (data.Expected["value"], FormatCoordinates(data.Expected["factors"]));
            }
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method)
        {
            if (method.Data.ExceptionThrown != null)
            {
                return method.Assert;
            }

            var assert = new StringBuilder();
            assert.AppendLine(Render.Assert.Equal("expected.Item1", "actual.Item1"));
            assert.AppendLine(Render.Assert.Equal("expected.Item2", "actual.Item2"));
            return assert.ToString();
        }

        private static string FormatCoordinates(dynamic coordinates)
            => Render.Object((coordinates as JArray).Select(coordinate => (coordinate[0].ToObject<int>(), coordinate[1].ToObject<int>())).ToArray());
    }
}