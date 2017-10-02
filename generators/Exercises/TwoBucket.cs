using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class TwoBucket : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
                canonicalDataCase.SetConstructorInputParameters("bucket_one", "bucket_two", "start_bucket");

                var start_bucket = canonicalDataCase.Properties["start_bucket"];
                canonicalDataCase.Properties["start_bucket"] = new UnescapedValue(start_bucket == "two" ? "Bucket.Two" : "Bucket.One");
            }
        }

        protected override string RenderTestMethodBodyAct(TestMethodBody testMethodBody)
        {
            const string template = @"var result = {{MethodInvocation}};";

            var templateParameters = new
            {
                MethodInvocation = testMethodBody.Data.TestedMethodInvocation
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            const string template =
@"Assert.Equal({{MovesExpected}}, result.Moves);
Assert.Equal({{OtherBucketExpected}}, result.OtherBucket);
Assert.Equal({% if GoalBucketExpected == 'two' %}Bucket.Two{% else %}Bucket.One{% endif %}, result.GoalBucket);";

            var templateParameters = new
            {
                MovesExpected = testMethodBody.CanonicalDataCase.Expected["moves"],
                OtherBucketExpected = testMethodBody.CanonicalDataCase.Expected["other_bucket"],
                GoalBucketExpected = testMethodBody.CanonicalDataCase.Expected["goal_bucket"],
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }
    }
}