using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Matrix : GeneratorExercise
    {
        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var canonicalDataCase = testMethodBody.CanonicalDataCase;
            var input = canonicalDataCase.Properties["input"] as System.Collections.Generic.Dictionary<string, object>;
            var template = "Assert.Equal(new[] { {{ExpectedData}} }, new Matrix(\"{{ConstructorData}}\").{{MethodName}}({{MethodCallArgumentValue}}));";
            var templateParams = new
            {
                ExpectedData = string.Join(", ", canonicalDataCase.Properties["expected"] as int[]),
                ConstructorData = input["string"].ToString().EscapeSpecialCharacters(),
                MethodName = canonicalDataCase.Property.Dehumanize(),
                MethodCallArgumentValue = input["index"]
            };
            return TemplateRenderer.RenderInline(template, templateParams);
        }
    }
}
