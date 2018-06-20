﻿using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
{
    public class Allergies : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            if (data.Property == "allergicTo")
                data.Property = "IsAllergicTo";
            else if (data.Property == "list")
                data.UseVariableForExpected = true;

            data.SetConstructorInputParameters("score");
        }

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            return testMethodBody.Data.Property == "IsAllergicTo"
                ? RenderIsAllergicToAssert(testMethodBody)
                : base.RenderTestMethodBodyAssert(testMethodBody);
        }

        private static IEnumerable<string> RenderIsAllergicToAssert(TestMethodBody testMethodBody)
        {
            const string template =
                @"{%- for allergy in Allergies -%}
Assert.{% if allergy.result %}True{% else %}False{% endif %}(sut.IsAllergicTo(""{{ allergy.substance }}""));
{%- endfor -%}";

            var templateParameters = new { Allergies = testMethodBody.Data.Expected };
            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}