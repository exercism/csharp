using System;
using System.Linq;
using System.Text;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class PalindromeProducts : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (ShouldThrowException(testMethod))
            {
                testMethod.ExceptionThrown = typeof(ArgumentException);
            }
            else
            {
                testMethod.UseVariableForTested = true;
                testMethod.UseVariableForExpected = true;
                testMethod.Expected = (testMethod.Expected["value"], RenderCoordinates(testMethod.Expected["factors"]));
                testMethod.Assert = RenderAssert();
            }
        }

        private static bool ShouldThrowException(TestMethod testMethod) =>
            testMethod.ExpectedIsError || testMethod.Expected["value"] is null;

        private string RenderAssert()
        {
            var assert = new StringBuilder();
            assert.AppendLine(Render.AssertEqual("expected.Item1", "actual.Item1"));
            assert.AppendLine(Render.AssertEqual("expected.Item2", "actual.Item2"));
            return assert.ToString();
        }

        private string RenderCoordinates(JArray coordinates)
            => Render.Object(coordinates
                .Select(RenderCoordinate)
                .ToArray());

        private static (int, int) RenderCoordinate(JToken coordinate)
            => (coordinate[0].ToObject<int>(), coordinate[1].ToObject<int>());
    }
}