using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;

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

        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Act = RenderTestMethodBodyAct(body);
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyAct(TestMethodBody testMethodBody)
        {
            const string template = @"var result = {{MethodInvocation}};";

            var templateParameters = new
            {
                MethodInvocation = testMethodBody.TestedMethodInvocation
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
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