using System.Collections.Generic;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Clock : Exercise
    {
        private const string paramClock1 = "clock1";
        private const string paramClock2 = "clock2";
        private const string paramHour = "hour";
        private const string paramMinute = "minute";

        private const string propertyCreate = "create";
        private const string propertyEqual = "equal";
        private const string propertyEquals = "equals";
        private const string propertyToString = "to_string";

        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                if (canonicalDataCase.Property != propertyEqual)
                {
                    canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                    {
                        [paramHour] = canonicalDataCase.Input[paramHour],
                        [paramMinute] = canonicalDataCase.Input[paramMinute]
                    };
                }
                else
                {
                    canonicalDataCase.ConstructorInput = ((JObject)canonicalDataCase.Input[paramClock1]).ToObject<Dictionary<string, object>>();
                    canonicalDataCase.Input.Remove(paramClock1);

                    var result = ((JObject)canonicalDataCase.Input[paramClock2]).ToObject<Dictionary<string, object>>();
                    canonicalDataCase.Input[paramClock2] = new UnescapedValue($"new Clock({result[paramHour]},{result[paramMinute]})");
                }

                if (canonicalDataCase.Property == propertyCreate)
                {
                    canonicalDataCase.Property = propertyToString;
                }
                else if (canonicalDataCase.Property == propertyEqual)
                {
                    canonicalDataCase.Property = propertyEquals;
                }
            }
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.CanonicalDataCase.Property == propertyEquals)
            {
                return base.RenderTestMethodBodyAssert(testMethodBody);
            }
            else if (testMethodBody.CanonicalDataCase.Property != propertyToString)
            {
                return RenderConsistencyToAssert(testMethodBody);
            }
            else
            {
                return base.RenderTestMethodBodyAssert(testMethodBody);
            }
        }

        private static string RenderConsistencyToAssert(TestMethodBody testMethodBody)
        {
            var template = $"Assert.Equal({{{{ ExpectedParameter }}}}, {{{{ TestedValue }}}}.ToString());";

            return TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters);
        }
    }
}