using System;
using System.Collections.Generic;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Meetup : GeneratorExercise
    {
        private const string ParamYear = "year";
        private const string ParamMonth = "month";
        private const string ParamWeek = "week";
        private const string ParamDayOfWeek = "dayofweek";

        private const string PropertyDay = "Day";

        protected override void UpdateTestData(TestData data)
        {
            data.Property = PropertyDay;
            data.UseVariableForExpected = true;
            data.SetConstructorInputParameters(ParamMonth, ParamYear);
            data.SetInputParameters(ParamDayOfWeek, ParamWeek);

            data.Input[ParamYear] = data.Input[ParamYear];
            data.Input[ParamMonth] = data.Input[ParamMonth];
            data.Input[ParamWeek] =
                new UnescapedValue($"Schedule.{((string)data.Input[ParamWeek]).Transform(To.SentenceCase)}");
            data.Input[ParamDayOfWeek] =
                new UnescapedValue($"DayOfWeek.{((string)data.Input[ParamDayOfWeek]).Transform(To.SentenceCase)}");
        }

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            const string template = "Assert.Equal({{ ExpectedParameter }}, {{ TestedValue }}.ToString(\"yyyy-MM-dd\"));";

            return new[] { TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters) };
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(DayOfWeek).Namespace };
    }
}
