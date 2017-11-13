using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class Allergies : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                if (canonicalDataCase.Property == "allergicTo")
                    canonicalDataCase.Property = "IsAllergicTo";
                else if (canonicalDataCase.Property == "list")
                    canonicalDataCase.UseVariableForExpected = true;

                canonicalDataCase.SetConstructorInputParameters("score");
            }
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.CanonicalDataCase.Property == "IsAllergicTo")
                return RenderIsAllergicToAssert(testMethodBody);

            return base.RenderTestMethodBodyAssert(testMethodBody);
        }

        private static string RenderIsAllergicToAssert(TestMethodBody testMethodBody)
        {
            const string template =
                @"{%- for allergy in Allergies -%}
Assert.{% if allergy.result %}True{% else %}False{% endif %}(sut.IsAllergicTo(""{{ allergy.substance }}""));
{%- endfor -%}";
            
            var templateParameters = new { Allergies = testMethodBody.CanonicalDataCase.Expected };
            return TemplateRenderer.RenderInline(template, templateParameters);
        }
    }
}