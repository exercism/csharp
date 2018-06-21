using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
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

        protected override IEnumerable<string> RenderTestMethodBodyAct(TestMethodBody testMethodBody)
        {
            const string template = @"var result = {{MethodInvocation}};";

            var templateParameters = new
            {
                MethodInvocation = testMethodBody.TestedMethodInvocation
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            const string template =
@"Assert.Equal({{MovesExpected}}, result.Moves);
Assert.Equal({{OtherBucketExpected}}, result.OtherBucket);
Assert.Equal({% if GoalBucketExpected == 'two' %}Bucket.Two{% else %}Bucket.One{% endif %}, result.GoalBucket);";

            var templateParameters = new
            {
                MovesExpected = testMethodBody.Data.Expected["moves"],
                OtherBucketExpected = testMethodBody.Data.Expected["otherBucket"],
                GoalBucketExpected = testMethodBody.Data.Expected["goalBucket"]
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}