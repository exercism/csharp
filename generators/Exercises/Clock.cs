using System.Collections.Generic;
using Generators.Input;
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
        private const string PropertyEquals = "equals";
        private const string PropertyToString = "to_string";

        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            if (canonicalDataCase.Property != PropertyEqual)
            {
                canonicalDataCase.SetConstructorInputParameters(ParamHour, ParamMinute);
            }
            else
            {
                canonicalDataCase.SetConstructorInputParameters(ParamClock2);

                var result = (Dictionary<string, object>)canonicalDataCase.Input[ParamClock1];
                canonicalDataCase.Input[ParamClock1] = new UnescapedValue($"new Clock({result[ParamHour]}, {result[ParamMinute]})");
            }

            if (canonicalDataCase.Property == PropertyCreate)
            {
                canonicalDataCase.Property = PropertyToString;
            }
            else if (canonicalDataCase.Property == PropertyEqual)
            {
                canonicalDataCase.Property = PropertyEquals;
            }
        }

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.CanonicalDataCase.Property == PropertyEquals)
            {
                return RenderEqualToAssert(testMethodBody);
            }

            return testMethodBody.CanonicalDataCase.Property != PropertyToString 
                ? RenderConsistencyToAssert(testMethodBody) 
                : base.RenderTestMethodBodyAssert(testMethodBody);
        }

        private static IEnumerable<string> RenderConsistencyToAssert(TestMethodBody testMethodBody)
        {
            const string template = "Assert.Equal({{ ExpectedParameter }}, {{ TestedValue }}.ToString());";
            return new[] { TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters) };
        }

        private static IEnumerable<string> RenderEqualToAssert(TestMethodBody testMethodBody)
        {
            var expectedParameter = testMethodBody.CanonicalDataCase.Input[ParamClock1];
            const string testedValue = "sut";
            var expectedEqual = testMethodBody.CanonicalDataCase.Expected;

            testMethodBody.AssertTemplateParameters = new { expectedParameter, testedValue };

            var template = expectedEqual
                ? "Assert.Equal({{ ExpectedParameter }}, {{ TestedValue }}); "
                : "Assert.NotEqual({{ ExpectedParameter }}, {{ TestedValue }});";

            return new[] { TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters) };
        }
    }
}