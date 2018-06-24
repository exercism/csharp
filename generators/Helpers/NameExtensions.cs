using System;
using System.Text.RegularExpressions;
using Humanizer;

namespace Exercism.CSharp.Helpers
{
    public static class NameExtensions
    {
        public static string ToExerciseName(this Type exerciseType) => exerciseType.Name.ToExerciseName();

        public static string ToExerciseName(this string input) => input.Kebaberize();

        public static string ToTestClassName(this string input) => $"{input.Dehumanize()}Test";

        public static string ToTestedClassName(this string input) => input.Dehumanize();

        public static string ToTestMethodName(this string input)
        {
            var methodName = input
                .Replace(":", " is")
                .Replace("'", "");

            methodName = Regex.Replace(methodName, @"[^\w]+", "_", RegexOptions.Compiled)
                .Transform(To.TitleCase);

            if (char.IsDigit(methodName[0]))
                return "Number_" + methodName;

            return !char.IsLetter(methodName[0]) ? "Test_" : methodName;
        }

        public static string ToTestedMethodName(this string input) => input.Dehumanize();

        public static string ToVariableName(this string input) => input.Camelize();
    }
}