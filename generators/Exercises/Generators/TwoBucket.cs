using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class TwoBucket : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethodType = TestedMethodType.Instance;
            data.SetConstructorInputParameters("bucketOne", "bucketTwo", "startBucket");
            data.Input["startBucket"] = Render.Enum("Bucket", data.Input["startBucket"]);
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Act = RenderAct(method);
            method.Assert = RenderAssert(method);
        }

        private static string RenderAct(TestMethod method) => $"var result = {method.TestedMethodInvocation};";

        private string RenderAssert(TestMethod method)
        {
            var assert = new StringBuilder();
            assert.AppendLine(Render.AssertEqual(method.Data.Expected["moves"].ToString(), "result.Moves"));
            assert.AppendLine(Render.AssertEqual(method.Data.Expected["otherBucket"].ToString(), "result.OtherBucket"));

            var expected = Render.Enum("Bucket", method.Data.Expected["goalBucket"]);
            assert.AppendLine(Render.AssertEqual(expected.ToString(), "result.GoalBucket"));
            
            return assert.ToString();
        }
    }
}