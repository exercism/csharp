using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RunLengthEncoding : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Description = $"{data.Property} {data.Description}";
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method)
        {
            return method.Data.Property == "consistency"
                ? RenderConsistencyToAssert(method)
                : method.Assert;
        }

        private static string RenderConsistencyToAssert(TestMethod method)
        {
            const string template = @"Assert.Equal(""{{Expected}}"", {{TestedClassName}}.Decode({{TestedClassName}}.Encode(""{{Expected}}"")));";

            var templateParameters = new
            {
                method.Data.Expected,
                TestedClassName = method.Data.TestedClass
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }
    }
}