using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Exercises.Generators
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

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method)
        {
            if (method.Data.Property == PropertyEqual)
            {
                return RenderEqualToAssert(method);
            }

            return method.Data.Property != PropertyCreate
                ? RenderConsistencyToAssert(method)
                : method.Assert;
        }

        private static string RenderConsistencyToAssert(TestMethod method)
        {
            const string template = "Assert.Equal({{ ExpectedParameter }}, {{ TestedValue }}.ToString());";
            return TemplateRenderer.RenderInline(template, new { method.ExpectedParameter, method.TestedValue });
        }

        private static string RenderEqualToAssert(TestMethod method)
        {
            var expectedParameter = method.Data.Input[ParamClock1];
            const string testedValue = "sut";
            var expectedEqual = method.Data.Expected;

            var assertTemplateParameters = new { expectedParameter, testedValue };

            var template = expectedEqual
                ? "Assert.Equal({{ ExpectedParameter }}, {{ TestedValue }}); "
                : "Assert.NotEqual({{ ExpectedParameter }}, {{ TestedValue }});";

            return TemplateRenderer.RenderInline(template, assertTemplateParameters);
        }
    }
}