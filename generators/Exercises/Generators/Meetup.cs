using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;
using Humanizer;

namespace Exercism.CSharp.Exercises.Generators
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
            data.TestedMethod = PropertyDay;
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

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method) 
            => Assertion.Equal(method.ExpectedParameter, $"{method.TestedValue}.ToString(\"yyyy-MM-dd\")");

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(DayOfWeek).Namespace);
        }
    }
}
