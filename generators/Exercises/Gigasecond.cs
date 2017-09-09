using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class Gigasecond : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                var input = DateTime.Parse(canonicalDataCase.Properties["input"].ToString());
                canonicalDataCase.Properties["input"] = new UnescapedValue(FormatDateTime(input));
                
                canonicalDataCase.Expected = new UnescapedValue(FormatDateTime((DateTime)canonicalDataCase.Expected));                
            }
        }

        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string> { typeof(DateTime).Namespace };

        private static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second == 0
                ? $"new DateTime({dateTime.Year}, {dateTime.Month}, {dateTime.Day})"
                : $"new DateTime({dateTime.Year}, {dateTime.Month}, {dateTime.Day}, {dateTime.Hour}, {dateTime.Minute}, {dateTime.Second})";
        }
    }
}