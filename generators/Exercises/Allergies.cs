using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Allergies : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                if (canonicalDataCase.Property == "allergicTo")
                {
                    canonicalDataCase.Property = "IsAllergicTo";
                }
                else if (canonicalDataCase.Property == "list")
                { 
                    canonicalDataCase.Expected = canonicalDataCase.Expected.ConvertToEnumerable<string>();
                    canonicalDataCase.UseVariableForExpected = true;
                }

                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["score"] = canonicalDataCase.Properties["score"]
                };
                canonicalDataCase.Input.Remove("score");
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
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
Assert.{% if allergy.Result %}True{% else %}False{% endif %}(sut.IsAllergicTo(""{{ allergy.Substance }}""));
{%- endfor -%}";

            var templateParameters = new
            {
                Allergies = ((JArray) testMethodBody.CanonicalDataCase.Expected)
                .Children<JObject>()
                .Select(x => new {Result = x["result"].Value<bool>(), Substance = x["substance"].Value<string>()})
                .ToArray()
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }
    }
}