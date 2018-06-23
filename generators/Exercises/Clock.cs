using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
{
    public class Clock : GeneratorExercise
    {
        private const string ParamClock1 = "clock1";
        private const string ParamClock2 = "clock2";
        private const string ParamHour = "hour";
        private const string ParamMinute = "minute";

        private const string PropertyCreate = "create";
        private const string PropertyEqual = "equal";

        protected override void UpdateTestData(TestData data)
        {
            if (data.Property != PropertyEqual)
            {
                data.SetConstructorInputParameters(ParamHour, ParamMinute);
            }
            else
            {
                data.SetConstructorInputParameters(ParamClock2);

                var result = (Dictionary<string, object>)data.Input[ParamClock1];
                data.Input[ParamClock1] = new UnescapedValue($"new Clock({result[ParamHour]}, {result[ParamMinute]})");
            }

            if (data.Property == PropertyCreate)
            {
                data.TestedMethod = "ToString";
            }
            else if (data.Property == PropertyEqual)
            {
                data.TestedMethod = "Equals";
            }
        }
        
        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.Data.Property == PropertyEqual)
            {
                return RenderEqualToAssert(testMethodBody);
            }

            return testMethodBody.Data.Property != PropertyCreate
                ? RenderConsistencyToAssert(testMethodBody)
                : testMethodBody.Assert;
        }

        private static IEnumerable<string> RenderConsistencyToAssert(TestMethodBody testMethodBody)
        {
            const string template = "Assert.Equal({{ ExpectedParameter }}, {{ TestedValue }}.ToString());";
            return new[] { TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters) };
        }

        private static IEnumerable<string> RenderEqualToAssert(TestMethodBody testMethodBody)
        {
            var expectedParameter = testMethodBody.Data.Input[ParamClock1];
            const string testedValue = "sut";
            var expectedEqual = testMethodBody.Data.Expected;

            testMethodBody.AssertTemplateParameters = new { expectedParameter, testedValue };

            var template = expectedEqual
                ? "Assert.Equal({{ ExpectedParameter }}, {{ TestedValue }}); "
                : "Assert.NotEqual({{ ExpectedParameter }}, {{ TestedValue }});";

            return new[] { TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters) };
        }
    }
}