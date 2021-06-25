using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class TwoBucket : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForTested = true;
            
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.ConstructorInputParameters = new[] { "bucketOne", "bucketTwo", "startBucket" };
            testMethod.Input["startBucket"] = Render.Enum("Bucket", testMethod.Input["startBucket"]);
            
            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAssert(TestMethod testMethod)
        {
            var assert = new StringBuilder();
            assert.AppendLine(Render.AssertEqual(testMethod.Expected["moves"].ToString(), "actual.Moves"));
            assert.AppendLine(Render.AssertEqual(testMethod.Expected["otherBucket"].ToString(), "actual.OtherBucket"));

            var expected = Render.Enum("Bucket", testMethod.Expected["goalBucket"]);
            assert.AppendLine(Render.AssertEqual(expected.ToString(), "actual.GoalBucket"));
            
            return assert.ToString();
        }
    }
}