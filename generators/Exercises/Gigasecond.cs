using System;
using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
{
    public class Gigasecond : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            var input = DateTime.Parse(data.Input["birthdate"].ToString());
            data.Input["birthdate"] = new UnescapedValue(FormatDateTime(input));
            data.Expected = new UnescapedValue(FormatDateTime((DateTime)data.Expected));
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(DateTime).Namespace };

        private static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second == 0
                ? $"new DateTime({dateTime.Year}, {dateTime.Month}, {dateTime.Day})"
                : $"new DateTime({dateTime.Year}, {dateTime.Month}, {dateTime.Day}, {dateTime.Hour}, {dateTime.Minute}, {dateTime.Second})";
        }
    }
}