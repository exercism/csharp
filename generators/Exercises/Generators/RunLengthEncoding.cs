using System.Collections.Generic;
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
        
        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody body)
        {
            return body.Data.Property == "consistency"
                ? RenderConsistencyToAssert(body)
                : body.Assert;
        }

        private static IEnumerable<string> RenderConsistencyToAssert(TestMethodBody body)
        {
            const string template = @"Assert.Equal(""{{Expected}}"", {{TestedClassName}}.Decode({{TestedClassName}}.Encode(""{{Expected}}"")));";

            var templateParameters = new
            {
                body.Data.Expected,
                TestedClassName = body.Data.TestedClass
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}