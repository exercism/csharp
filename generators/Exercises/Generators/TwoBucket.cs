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

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Act = RenderAct(method);
            method.Assert = RenderAssert(method);
        }

        private static string RenderAct(TestMethod method)
        {
            const string template = @"var result = {{MethodInvocation}};";

            var templateParameters = new
            {
                MethodInvocation = method.TestedMethodInvocation
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }

        private static string RenderAssert(TestMethod method)
        {
            const string template =
@"Assert.Equal({{MovesExpected}}, result.Moves);
Assert.Equal({{OtherBucketExpected}}, result.OtherBucket);
Assert.Equal({% if GoalBucketExpected == 'two' %}Bucket.Two{% else %}Bucket.One{% endif %}, result.GoalBucket);";

            var templateParameters = new
            {
                MovesExpected = method.Data.Expected["moves"],
                OtherBucketExpected = method.Data.Expected["otherBucket"],
                GoalBucketExpected = method.Data.Expected["goalBucket"]
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }
    }
}