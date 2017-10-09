using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Generators.Output
{
    public static class ValueFormatter
    {
        public static object Format(object val)
        {
            switch (val)
            {
                case string str: return str.Format();
                case double dbl: return dbl.Format();
                case float flt: return flt.Format();
                case ulong ulng: return ulng.Format();
                case char c: return c.Format();
                case Enum enumeration: return enumeration.Format();
                case Tuple<string, object> tuple: return tuple.Format();
                case IEnumerable<int> ints: return ints.Format();
                case IEnumerable<string> strings: return strings.Format();
                case IEnumerable<UnescapedValue> unescapedValues when unescapedValues.Any(): return unescapedValues.Format();
                case IDictionary<string, object> dict: return dict.Format();
                case IDictionary<char, int> dict: return dict.Format();
                case IDictionary<string, int> dict: return dict.Format();
                case JArray jArray: return jArray.Format();
                case int[,] multidimensionalArray: return multidimensionalArray.Format();
                case IEnumerable<Tuple<string, object>> tuples: return tuples.Format();
                default: return val;
            }
        }

        public static string[] FormatVariables(IReadOnlyDictionary<string, object> dict)
            => dict.Keys.SelectMany(key => FormatVariable(dict[key], key.ToVariableName())).ToArray();

        public static string[] FormatVariable(object val, string name)
        {
            switch (val)
            {
                case string str when str.Contains("\n"):
                    return FormatMultiLineString(name, str);
                case IDictionary<char, int> dict:
                    return FormatMultiLineEnumerable(dict.Keys.Select((key, i) => $"[{Format(key)}] = {Format(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name, "new Dictionary<char, int>");
                case IDictionary<string, int> dict:
                    return FormatMultiLineEnumerable(dict.Keys.Select((key, i) => $"[{Format(key)}] = {Format(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name, "new Dictionary<string, int>");
                default:
                    return new[] { $"var {name} = {Format(val)};" };
            }
        }

        private static string Format(this string s) => s.EscapeSpecialCharacters().Quote();

        private static string Format(this char c) => $"'{c}'";

        private static string Format(this double dbl) => dbl.ToString(CultureInfo.InvariantCulture);

        private static string Format(this float flt) => flt.ToString(CultureInfo.InvariantCulture);

        private static string Format(this ulong ulng) => $"{ulng}UL";

        private static string Format(this Enum @enumeration) =>
            $"{enumeration.GetType().Name}.{enumeration}";

        private static string Format(this Tuple<string, object> tuple) =>
            $"Tuple.Create({tuple.Item1}, {tuple.Item2})";

        private static string Format(this IEnumerable<int> ints) => ints.Any() ?
           $"new[] {{ {string.Join(", ", ints)} }}" : "new int[0]";

        private static string Format(this IEnumerable<string> strings) =>
            strings.Any() ? $"new[] {{ {string.Join(", ", strings.Select(Format))} }}" : "new string[0]";

        private static string Format(this IEnumerable<UnescapedValue> unescapedValues) =>
            $"new[] {{ {string.Join(", ", unescapedValues.Select(Format))} }}";

        private static string Format(this IDictionary<string, object> dict) => 
            string.Join(", ", dict.Values.Select(Format));

        private static string Format(this IDictionary<char, int> dict) =>
            $"new Dictionary<char, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Format(key)}] = {Format(dict[key])}"))} }}";

        private static string Format(this IDictionary<string, int> dict) =>
            $"new Dictionary<string, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Format(key)}] = {Format(dict[key])}"))} }}";

        private static string Format(this JArray jArray) => 
            $"new[] {{ {string.Join(", ", jArray.Select(Format))} }}";

        private static string Format(this int[,] multidimensionalArray)
        {
            return multidimensionalArray.GetLength(0) > 1
                            ? $"new[,]\r\n{{\r\n    {string.Join(",\r\n    ", Enumerable.Range(0, multidimensionalArray.GetUpperBound(0) + 1).Select(x => multidimensionalArray.SliceRow(x).ToNestedArray()))}\r\n}}"
                            : "new int[,] { }";
        }

        private static string Format(this IEnumerable<Tuple<string, object>> tuples) => 
            $"new[] {{ {string.Join(", ", tuples.Select(Format))} }}";

        private static string ToNestedArray<T>(this IEnumerable<T> enumerable) =>
            enumerable.Any() ? $"{{ {string.Join(", ", enumerable)} }}" : string.Empty;

        private static string[] FormatMultiLineString(string name, string str)
        {
            var strings = str.Split('\n');
            var formattedStrings = strings
                .Select((t, i) => i < strings.Length - 1
                    ? $"{Format(t + "\n")} +"
                    : $"{Format(t)}");

            return FormatMultiLineVariable(formattedStrings, name);
        }

        private static string[] FormatMultiLineEnumerable(IEnumerable<string> enumerable, string name, string constructor = null)
            => FormatMultiLineVariable(enumerable.Prepend("{").Append("}"), name, constructor);

        private static string[] FormatMultiLineVariable(IEnumerable<string> enumerable, string name, string constructor = null)
            => enumerable.Select(line => line == "{" || line == "}" ? line : line.Indent())
                .AddTrailingSemicolon()
                .Prepend($"var {name} = {constructor}")
                .ToArray();
    }
}