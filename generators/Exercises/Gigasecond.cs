using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class Gigasecond : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            var input = DateTime.Parse(canonicalDataCase.Input["birthdate"].ToString());
            canonicalDataCase.Input["birthdate"] = new UnescapedValue(FormatDateTime(input));
            canonicalDataCase.Expected = new UnescapedValue(FormatDateTime((DateTime)canonicalDataCase.Expected));
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