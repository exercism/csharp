using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Exercism.CSharp.Helpers;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Output
{
    public static class ValueFormatter
    {
        public static string Format(object val)
        {
            switch (val)
            {
                case string str: return str.Format();
                case MultiLineString multiLineString: return multiLineString.ToString().Format();
                case double dbl: return dbl.Format();
                case float flt: return flt.Format();
                case ulong ulng: return ulng.Format();
                case char c: return c.Format();
                case Enum enumeration: return enumeration.Format();
                case Tuple<string, object> tuple: return tuple.Format();
                case List<int> ints: return ints.Format();
                case List<object> objects: return objects.Format();
                case IEnumerable<int> ints: return ints.Format();
                case IEnumerable<string> strings: return strings.Format();
                case IEnumerable<UnescapedValue> unescapedValues when unescapedValues.Any(): return unescapedValues.Format();
                case IDictionary<string, object> dict: return dict.Format();
                case IDictionary<char, int> dict: return dict.Format();
                case IDictionary<string, int> dict: return dict.Format();
                case IDictionary<int, string[]> dict: return dict.Format();
                case JArray jArray: return jArray.Format();
                case int[,] multidimensionalArray: return multidimensionalArray.Format();
                case IEnumerable<ValueTuple<int, int>> tuples: return tuples.Format();
                case IEnumerable<Tuple<string, object>> tuples: return tuples.Format();
                case IEnumerable<object> objects: return objects.Format();
                default: return val?.ToString();
            }
        }

        public static IEnumerable<string> FormatVariables(IDictionary<string, object> dict)
            => dict.Keys.SelectMany(key => FormatVariable(dict[key], key.ToVariableName())).ToArray();

        public static IEnumerable<string> FormatVariable(object val, string name)
        {
            switch (val)
            {
                case string str when str.Contains("\n"):
                    return FormatMultiLineString(name, str);
                case MultiLineString multiLineValue when multiLineValue.ToString().Contains("\n"):
                    return FormatMultiLineString(name, multiLineValue.ToString());
                case IEnumerable<string> strings:
                    if (!strings.Any())
                    {
                        return new[] { $"var {name} = Array.Empty<string>();" };
                    }

                    return FormatMultiLineEnumerable(strings.Select((str, i) => str.Format() + (i < strings.Count() - 1 ? "," : "")), name, "new[]");
                case IDictionary<char, int> dict:
                    return FormatMultiLineEnumerable(dict.Keys.Select((key, i) => $"[{Format(key)}] = {Format(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name, "new Dictionary<char, int>");
                case IDictionary<string, int> dict:
                    return FormatMultiLineEnumerable(dict.Keys.Select((key, i) => $"[{Format(key)}] = {Format(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name, "new Dictionary<string, int>");
                case IDictionary<int, string[]> dict:
                    return FormatMultiLineEnumerable(dict.Keys.Select((key, i) => $"[{Format(key)}] = {Format(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name, "new Dictionary<int, string[]>");
                case IEnumerable<ValueTuple<int, int>> tuples:
                    return new[] { tuples.Format() };
                default:
                    return new[] { $"var {name} = {Format(val)};" };
            }
        }

        private static string Format(this string s) => s.EscapeSpecialCharacters().Quote();

        private static string Format(this char c) => $"'{c}'";

        private static string Format(this double dbl) => dbl.ToString(CultureInfo.InvariantCulture);

        private static string Format(this float flt) => flt.ToString(CultureInfo.InvariantCulture);

        private static string Format(this int i) => i.ToString(CultureInfo.InvariantCulture);

        private static string Format(this ulong ulng) => $"{ulng}UL";

        private static string Format(this Enum enumeration) =>
            $"{enumeration.GetType().Name}.{enumeration}";

        private static string Format(this Tuple<string, object> tuple) =>
            $"Tuple.Create({tuple.Item1}, {tuple.Item2})";

        private static string Format(this IEnumerable<int> ints) => ints.Any() ?
           $"new[] {{ {string.Join(", ", ints)} }}" : "Array.Empty<int>()";

        private static string Format(this IEnumerable<string> strings) =>
            strings.Any() ? $"new[] {{ {string.Join(", ", strings.Select(Format))} }}" : "Array.Empty<string>()";

        private static string Format(this IEnumerable<object> objects) =>
            objects.Any() ? $"new[] {{ {string.Join(", ", objects.Select(Format))} }}" : "Array.Empty<object>()";

        private static string Format(this List<int> ints) =>
            ints.Any() ? $"new List<int> {{ {string.Join(", ", ints.Select(Format))} }}" : "new List<int>()";

        private static string Format(this List<object> objects) =>
            objects.Any() ? $"new List<object> {{ {string.Join(", ", objects.Select(Format))} }}" : "new List<object>()";

        private static string Format(this IEnumerable<UnescapedValue> unescapedValues) =>
            $"new[] {{ {string.Join(", ", unescapedValues.Select(Format))} }}";

        private static string Format(this IEnumerable<ValueTuple<int, int>> tuples) => tuples.Any() ?
           $"new[] {{ {string.Join(", ", tuples)} }}" : "Array.Empty<ValueTuple<int,int>>()";

        private static string Format(this IDictionary<string, object> dict) =>
            string.Join(", ", dict.Values.Select(Format));

        private static string Format(this IDictionary<char, int> dict) =>
            $"new Dictionary<char, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Format(key)}] = {Format(dict[key])}"))} }}";

        private static string Format(this IDictionary<string, int> dict) =>
            $"new Dictionary<string, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Format(key)}] = {Format(dict[key])}"))} }}";

        private static string Format(this IDictionary<int, string[]> dict) =>
            $"new Dictionary<int, string[]> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Format(key)}] = {Format(dict[key])}"))} }}";

        private static string Format(this JArray jArray) =>
            $"new[] {{ {string.Join(", ", jArray.Select(Format))} }}";

        private static string Format(this int[,] multidimensionalArray)
        {
            return multidimensionalArray.GetLength(0) > 0
                            ? $"new[,]\r\n{{\r\n    {string.Join(",\r\n    ", Enumerable.Range(0, multidimensionalArray.GetUpperBound(0) + 1).Select(x => multidimensionalArray.SliceRow(x).ToNestedArray()))}\r\n}}"
                            : "new int[,] { }";
        }

        private static string Format(this IEnumerable<Tuple<string, object>> tuples) =>
            $"new[] {{ {string.Join(", ", tuples.Select(Format))} }}";

        private static string ToNestedArray<T>(this IEnumerable<T> enumerable) =>
            enumerable.Any() ? $"{{ {string.Join(", ", enumerable)} }}" : string.Empty;

        private static IEnumerable<string> FormatMultiLineString(string name, string str)
        {
            var strings = str.Split('\n');
            var formattedStrings = strings
                .Select((t, i) => i < strings.Length - 1
                    ? $"{Format(t + "\n")} +"
                    : $"{Format(t)}");

            return FormatMultiLineVariable(formattedStrings, name);
        }

        private static IEnumerable<string> FormatMultiLineEnumerable(IEnumerable<string> enumerable, string name, string constructor = null)
            => FormatMultiLineVariable(enumerable.Prepend("{").Append("}"), name, constructor);

        private static IEnumerable<string> FormatMultiLineVariable(IEnumerable<string> enumerable, string name, string constructor = null)
            => enumerable.Select(line => line == "{" || line == "}" ? line : line.Indent())
                .AddTrailingSemicolon()
                .Prepend($"var {name} = {constructor}")
                .ToArray();
    }
}