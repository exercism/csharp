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
                data.Expected = (data.Expected["value"], RenderCoordinates(data.Expected["factors"]));
            }
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private string RenderAssert(TestMethod method)
        {
            if (method.Data.ExceptionThrown != null)
            {
                return method.Assert;
            }

            var assert = new StringBuilder();
            assert.AppendLine(Render.AssertEqual("expected.Item1", "actual.Item1"));
            assert.AppendLine(Render.AssertEqual("expected.Item2", "actual.Item2"));
            return assert.ToString();
        }

        private string RenderCoordinates(dynamic coordinates)
            => Render.Object((coordinates as JArray)
                .Select(RenderCoordinate)
                .ToArray());

        private static (int, int) RenderCoordinate(JToken coordinate)
            => (coordinate[0].ToObject<int>(), coordinate[1].ToObject<int>());
    }
}