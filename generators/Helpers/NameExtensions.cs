using System;
using System.Linq;
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

        public static string ToBuiltInTypeName(this Type type)
        {
            if (type.GenericTypeArguments.Any())
            {
                var genericTypeName = type.Name.Substring(0, type.Name.IndexOf("`", StringComparison.OrdinalIgnoreCase));
                var genericTypeArguments = string.Join(",", type.GenericTypeArguments.Select(ToBuiltInTypeName));
                return $"{genericTypeName}<{genericTypeArguments}>";
            }   

            switch (type.FullName)
            {
                case "System.Int32":
                    return "int";
                case "System.Object":
                    return "object";
                case "System.String":
                    return "string";
                default:
                    return type.Name;
            }
        }
    }
}