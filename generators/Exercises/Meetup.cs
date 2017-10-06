using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Meetup : Exercise
    {
        private const string ParamYear = "year";
        private const string ParamMonth = "month";
        private const string ParamDay = "dayofmonth";
        private const string ParamSchedule = "week";
        private const string ParamDayOfWeek = "dayofweek";

        private const string PropertyDay = "Day";

        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Property = PropertyDay;
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.SetConstructorInputParameters(ParamMonth, ParamYear);
                canonicalDataCase.SetInputParameters(ParamDayOfWeek, ParamSchedule);

                canonicalDataCase.Properties[ParamSchedule] =
                    new UnescapedValue($"Schedule.{((string)canonicalDataCase.Properties[ParamSchedule]).Transform(To.SentenceCase)}");
                canonicalDataCase.Properties[ParamDayOfWeek] =
                    new UnescapedValue($"DayOfWeek.{((string)canonicalDataCase.Properties[ParamDayOfWeek]).Transform(To.SentenceCase)}");
                canonicalDataCase.Expected =
                    $"{canonicalDataCase.Properties[ParamYear]}-{canonicalDataCase.Properties[ParamMonth]}-{canonicalDataCase.Properties[ParamDay]}";
            }
        }

        protected override String RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            string template = $"Assert.Equal({{{{ ExpectedParameter }}}}, {{{{ TestedValue }}}}.ToString(\"yyyy-M-d\"));";

            return TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters);
        }

        protected override HashSet<String> AddAdditionalNamespaces() => new HashSet<string> { typeof(DayOfWeek).Namespace };
    }
}
