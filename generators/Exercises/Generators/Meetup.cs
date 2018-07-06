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

        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = PropertyDay;
            testMethod.UseVariableForExpected = true;
            testMethod.SetConstructorInputParameters(ParamMonth, ParamYear);
            testMethod.SetInputParameters(ParamDayOfWeek, ParamWeek);

            testMethod.Input[ParamYear] = testMethod.Input[ParamYear];
            testMethod.Input[ParamMonth] = testMethod.Input[ParamMonth];
            testMethod.Input[ParamWeek] = Render.Enum("Schedule", testMethod.Input[ParamWeek]);
            testMethod.Input[ParamDayOfWeek] = Render.Enum("DayOfWeek", testMethod.Input[ParamDayOfWeek]);

            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAssert(TestMethod testMethod) 
            => Render.AssertEqual(testMethod.ExpectedParameter, $"{testMethod.TestedValue}.ToString(\"yyyy-MM-dd\")");

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(DayOfWeek).Namespace);
        }
    }
}
