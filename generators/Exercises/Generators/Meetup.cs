using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;

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
            data.Input[ParamWeek] = Render.Enum("Schedule", data.Input[ParamWeek]);
            data.Input[ParamDayOfWeek] = Render.Enum("DayOfWeek", data.Input[ParamDayOfWeek]);
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private string RenderAssert(TestMethod method) 
            => Render.AssertEqual(method.ExpectedParameter, $"{method.TestedValue}.ToString(\"yyyy-MM-dd\")");

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(DayOfWeek).Namespace);
        }
    }
}
