using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class TwoBucket : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.SetConstructorInputParameters("bucketOne", "bucketTwo", "startBucket");
            testMethod.Input["startBucket"] = Render.Enum("Bucket", testMethod.Input["startBucket"]);

            testMethod.Act = RenderAct(testMethod);
            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAct(TestMethod testMethod) => Render.Variable("result", testMethod.TestedMethodInvocation);

        private string RenderAssert(TestMethod testMethod)
        {
            var assert = new StringBuilder();
            assert.AppendLine(Render.AssertEqual(testMethod.Expected["moves"].ToString(), "result.Moves"));
            assert.AppendLine(Render.AssertEqual(testMethod.Expected["otherBucket"].ToString(), "result.OtherBucket"));

            var expected = Render.Enum("Bucket", testMethod.Expected["goalBucket"]);
            assert.AppendLine(Render.AssertEqual(expected.ToString(), "result.GoalBucket"));
            
            return assert.ToString();
        }
    }
}