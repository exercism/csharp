using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class Allergies : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            if (canonicalDataCase.Property == "allergicTo")
                canonicalDataCase.Property = "IsAllergicTo";
            else if (canonicalDataCase.Property == "list")
                canonicalDataCase.UseVariableForExpected = true;

            canonicalDataCase.SetConstructorInputParameters("score");
        }

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            return testMethodBody.Data.CanonicalDataCase.Property == "IsAllergicTo" 
                ? RenderIsAllergicToAssert(testMethodBody) 
                : base.RenderTestMethodBodyAssert(testMethodBody);
        }

        private static IEnumerable<string> RenderIsAllergicToAssert(TestMethodBody testMethodBody)
        {
            const string template =
                @"{%- for allergy in Allergies -%}
Assert.{% if allergy.result %}True{% else %}False{% endif %}(sut.IsAllergicTo(""{{ allergy.substance }}""));
{%- endfor -%}";

            var templateParameters = new { Allergies = testMethodBody.Data.CanonicalDataCase.Expected };
            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}