using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;
using Humanizer;

namespace Exercism.CSharp.Exercises.Generators
{
    public class TwoBucket : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethodType = TestedMethodType.Instance;
            data.SetConstructorInputParameters("bucketOne", "bucketTwo", "startBucket");

            var startBucket = data.Input["startBucket"];
            data.Input["startBucket"] = new UnescapedValue(startBucket == "two" ? "Bucket.Two" : "Bucket.One");
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Act = RenderAct(method);
            method.Assert = RenderAssert(method);
        }

        private static string RenderAct(TestMethod method) => $"var result = {method.TestedMethodInvocation};";

        private static string RenderAssert(TestMethod method)
        {
            var assert = new StringBuilder();
            assert.AppendLine(Assertion.Equal(method.Data.Expected["moves"].ToString(), "result.Moves"));
            assert.AppendLine(Assertion.Equal(method.Data.Expected["otherBucket"].ToString(), "result.OtherBucket"));

            var goalBucket = (string) method.Data.Expected["goalBucket"];
            var expected = $"Bucket.{goalBucket.Humanize()}";
            assert.AppendLine(Assertion.Equal(expected, "result.GoalBucket"));
            
            return assert.ToString();
        }
    }
}