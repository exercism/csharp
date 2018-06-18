using System;
using System.Collections.Generic;
using Generators.Input;
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

        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Property = PropertyDay;
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.SetConstructorInputParameters(ParamMonth, ParamYear);
                canonicalDataCase.SetInputParameters(ParamDayOfWeek, ParamWeek);

                canonicalDataCase.Input[ParamYear] = canonicalDataCase.Input[ParamYear];
                canonicalDataCase.Input[ParamMonth] = canonicalDataCase.Input[ParamMonth];
                canonicalDataCase.Input[ParamWeek] =
                    new UnescapedValue($"Schedule.{((string)canonicalDataCase.Input[ParamWeek]).Transform(To.SentenceCase)}");
                canonicalDataCase.Input[ParamDayOfWeek] =
                    new UnescapedValue($"DayOfWeek.{((string)canonicalDataCase.Input[ParamDayOfWeek]).Transform(To.SentenceCase)}");
            }
        }

        protected override String RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            string template = $"Assert.Equal({{{{ ExpectedParameter }}}}, {{{{ TestedValue }}}}.ToString(\"yyyy-MM-dd\"));";

            return TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters);
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(DayOfWeek).Namespace };
    }
}
