using System.Collections.Generic;
using System.Linq;
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
        private const string propertyToString = "to_string";

        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            //canonicalData.Cases = canonicalData.Cases.Where(c => c.Property != "equal").ToArray();

            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;

                if (canonicalDataCase.Property != propertyEqual)
                {
                    canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                    {
                        [paramHour] = canonicalDataCase.Input[paramHour],
                        [paramMinute] = canonicalDataCase.Input[paramMinute]
                    };

                    canonicalDataCase.Input.Remove(paramHour);
                    canonicalDataCase.Input.Remove(paramMinute);
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
            }
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.CanonicalDataCase.Property == propertyEqual)
            {
                return base.RenderTestMethodBodyAssert(testMethodBody);
            }
            else if (testMethodBody.CanonicalDataCase.Property != propertyToString)
            {
                return RenderConsistencyToAssert(testMethodBody, false, true);
            }
            else
            {
                return base.RenderTestMethodBodyAssert(testMethodBody);
            }
        }

        private static string RenderConsistencyToAssert(TestMethodBody testMethodBody, bool addToStringForExpected, bool addToStringForTested)
        {
            var expectedStringSuffix = addToStringForExpected ? ".ToString()" : string.Empty;
            var testedStringSuffix = addToStringForTested ? ".ToString()" : string.Empty;

            var template = $"Assert.Equal({{{{ ExpectedParameter }}}}{expectedStringSuffix}, {{{{ TestedValue }}}}{testedStringSuffix});";

            return TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters);
        }
    }
}