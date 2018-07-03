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

        public static string ToTestedMethodName(this string input) => input.ToMethodName();
        
        public static string ToMethodName(this string input) => input.Dehumanize();

        public static string ToVariableName(this string input) => input.Camelize();

        public static string ToFriendlyName(this Type type)
        {
            if (type == typeof(int))
                return "int";
            if (type == typeof(short))
                return "short";
            if (type == typeof(byte))
                return "byte";
            if (type == typeof(bool)) 
                return "bool";
            if (type == typeof(long))
                return "long";
            if (type == typeof(float))
                return "float";
            if (type == typeof(double))
                return "double";
            if (type == typeof(decimal))
                return "decimal";
            if (type == typeof(string))
                return "string";
            if (type == typeof(char))
                return "char";
            if (type.IsGenericType)
                return $"{type.Name.Split('`')[0]}<{string.Join(", ", type.GetGenericArguments().Select(ToFriendlyName).ToArray())}>";
            if (type.IsArray)
                return $"{type.GetElementType().ToFriendlyName()}[]";
            return type.Name;
        }
    }
}