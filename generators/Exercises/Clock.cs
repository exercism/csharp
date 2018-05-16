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

        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                if (canonicalDataCase.Property != PropertyEqual)
                {
                    canonicalDataCase.SetConstructorInputParameters(ParamHour, ParamMinute);
                }
                else
                {
                    canonicalDataCase.SetConstructorInputParameters(ParamClock1);

                    var result = (Dictionary<string, object>)canonicalDataCase.Input[ParamClock2];
                    canonicalDataCase.Input[ParamClock2] = new UnescapedValue($"new Clock({result[ParamHour]}, {result[ParamMinute]})");
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
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.CanonicalDataCase.Property == PropertyEquals)
            {
                return RenderEqualToAssert(testMethodBody);
            }
            else if (testMethodBody.CanonicalDataCase.Property != PropertyToString)
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

        private static string RenderEqualToAssert(TestMethodBody testMethodBody)
        {
            var ExpectedParameter = testMethodBody.CanonicalDataCase.Input[ParamClock2];
            var TestedValue = "sut";
            var expectedEqual = testMethodBody.CanonicalDataCase.Expected;

            testMethodBody.AssertTemplateParameters = new { ExpectedParameter, TestedValue };

            var template = expectedEqual
                ? $"Assert.Equal({{{{ ExpectedParameter }}}}, {{{{ TestedValue }}}}); "
                : $"Assert.NotEqual({{{{ ExpectedParameter }}}}, {{{{ TestedValue }}}});";

            return TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters);
        }
    }
}