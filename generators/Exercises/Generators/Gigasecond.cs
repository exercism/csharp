using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Gigasecond : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            var input = DateTime.Parse(testMethod.Input["birthdate"].ToString());
            testMethod.Input["birthdate"] = new UnescapedValue(RenderDateTime(input));
            testMethod.Expected = new UnescapedValue(RenderDateTime((DateTime)testMethod.Expected));
        }

        private static string RenderDateTime(DateTime dateTime)
        {
            return dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second == 0
                ? $"new DateTime({dateTime.Year}, {dateTime.Month}, {dateTime.Day})"
                : $"new DateTime({dateTime.Year}, {dateTime.Month}, {dateTime.Day}, {dateTime.Hour}, {dateTime.Minute}, {dateTime.Second})";
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(DateTime).Namespace);
        }
    }
}