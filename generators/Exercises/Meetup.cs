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

                canonicalDataCase.Properties[ParamYear] = canonicalDataCase.Properties["input"][ParamYear];
                canonicalDataCase.Properties[ParamMonth] = canonicalDataCase.Properties["input"][ParamMonth];
                canonicalDataCase.Properties[ParamWeek] =
                    new UnescapedValue($"Schedule.{((string)canonicalDataCase.Properties["input"][ParamWeek]).Transform(To.SentenceCase)}");
                canonicalDataCase.Properties[ParamDayOfWeek] =
                    new UnescapedValue($"DayOfWeek.{((string)canonicalDataCase.Properties["input"][ParamDayOfWeek]).Transform(To.SentenceCase)}");
            }
        }

        protected override String RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            string template = $"Assert.Equal({{{{ ExpectedParameter }}}}, {{{{ TestedValue }}}}.ToString(\"yyyy-MM-dd\"));";

            return TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters);
        }

        protected override HashSet<String> AddAdditionalNamespaces() => new HashSet<string> { typeof(DayOfWeek).Namespace };
    }
}
