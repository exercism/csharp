using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class TwoBucket : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
            canonicalDataCase.SetConstructorInputParameters("bucketOne", "bucketTwo", "startBucket");

            var startBucket = canonicalDataCase.Input["startBucket"];
            canonicalDataCase.Input["startBucket"] = new UnescapedValue(startBucket == "two" ? "Bucket.Two" : "Bucket.One");
        }

        protected override IEnumerable<string> RenderTestMethodBodyAct(TestMethodBody testMethodBody)
        {
            const string template = @"var result = {{MethodInvocation}};";

            var templateParameters = new
            {
                MethodInvocation = testMethodBody.Data.TestedMethodInvocation
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
                MovesExpected = testMethodBody.Data.CanonicalDataCase.Expected["moves"],
                OtherBucketExpected = testMethodBody.Data.CanonicalDataCase.Expected["otherBucket"],
                GoalBucketExpected = testMethodBody.Data.CanonicalDataCase.Expected["goalBucket"]
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}