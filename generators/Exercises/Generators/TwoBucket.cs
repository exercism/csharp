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

        private static IEnumerable<string> RenderTestMethodBodyAct(TestMethodBody body)
        {
            const string template = @"var result = {{MethodInvocation}};";

            var templateParameters = new
            {
                MethodInvocation = body.TestedMethodInvocation
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody body)
        {
            const string template =
@"Assert.Equal({{MovesExpected}}, result.Moves);
Assert.Equal({{OtherBucketExpected}}, result.OtherBucket);
Assert.Equal({% if GoalBucketExpected == 'two' %}Bucket.Two{% else %}Bucket.One{% endif %}, result.GoalBucket);";

            var templateParameters = new
            {
                MovesExpected = body.Data.Expected["moves"],
                OtherBucketExpected = body.Data.Expected["otherBucket"],
                GoalBucketExpected = body.Data.Expected["goalBucket"]
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}