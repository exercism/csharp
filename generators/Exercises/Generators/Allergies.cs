using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Allergies : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Property == "allergicTo")
                data.TestedMethod = "IsAllergicTo";
            else if (data.Property == "list")
                data.UseVariableForExpected = true;

            data.SetConstructorInputParameters("score");
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method)
        {
            return method.Data.Property == "allergicTo"
                ? RenderIsAllergicToAssert(method)
                : method.Assert;
        }

        private static string RenderIsAllergicToAssert(TestMethod method)
        {
            const string template =
                @"{%- for allergy in Allergies -%}
Assert.{% if allergy.result %}True{% else %}False{% endif %}(sut.IsAllergicTo(""{{ allergy.substance }}""));
{%- endfor -%}";

            var templateParameters = new { Allergies = method.Data.Expected };
            return TemplateRenderer.RenderInline(template, templateParameters);
        }
    }
}