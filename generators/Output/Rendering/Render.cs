using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Exercism.CSharp.Helpers;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Output.Rendering
{
    public static class Render
    {   
        public static readonly RenderAssert Assert = new RenderAssert();
        
        public static string Object(object val)
        {
            switch (val)
            {
                case string str: return str.Object();
                case MultiLineString multiLineString: return multiLineString.ToString().Object();
                case double dbl: return dbl.Object();
                case float flt: return flt.Object();
                case ulong ulng: return ulng.Object();
                case char c: return c.Object();
                case Enum enumeration: return enumeration.Object();
                case Tuple<string, object> tuple: return tuple.Object();
                case List<int> ints: return ints.Object();
                case List<object> objects: return objects.Object();
                case IEnumerable<int> ints: return ints.Object();
                case IEnumerable<string> strings: return strings.Object();
                case IEnumerable<UnescapedValue> unescapedValues when unescapedValues.Any(): return unescapedValues.Object();
                case IDictionary<string, object> dict: return dict.Object();
                case IDictionary<char, int> dict: return dict.Object();
                case IDictionary<string, int> dict: return dict.Object();
                case IDictionary<int, string[]> dict: return dict.Object();
                case JArray jArray: return jArray.Object();
                case int[,] multidimensionalArray: return multidimensionalArray.Object();
                case IEnumerable<ValueTuple<int, int>> tuples: return tuples.Object();
                case IEnumerable<Tuple<string, object>> tuples: return tuples.Object();
                case IEnumerable<object> objects: return objects.Object();
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

                    return FormatMultiLineEnumerable(strings.Select((str, i) => str.Object() + (i < strings.Count() - 1 ? "," : "")), name, "new[]");
                case IDictionary<char, int> dict:
                    return FormatMultiLineEnumerable(dict.Keys.Select((key, i) => $"[{Object(key)}] = {Object(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name, "new Dictionary<char, int>");
                case IDictionary<string, int> dict:
                    return FormatMultiLineEnumerable(dict.Keys.Select((key, i) => $"[{Object(key)}] = {Object(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name, "new Dictionary<string, int>");
                case IDictionary<int, string[]> dict:
                    return FormatMultiLineEnumerable(dict.Keys.Select((key, i) => $"[{Object(key)}] = {Object(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name, "new Dictionary<int, string[]>");
                case IEnumerable<ValueTuple<int, int>> tuples:
                    return new[] { tuples.Object() };
                default:
                    return new[] { $"var {name} = {Object(val)};" };
            }
        }

        private static string Object(this string s) => s.EscapeSpecialCharacters().Quote();

        private static string Object(this char c) => $"'{c}'";

        private static string Object(this double dbl) => dbl.ToString(CultureInfo.InvariantCulture);

        private static string Object(this float flt) => flt.ToString(CultureInfo.InvariantCulture);

        private static string Object(this int i) => i.ToString(CultureInfo.InvariantCulture);

        private static string Object(this ulong ulng) => $"{ulng}UL";

        private static string Object(this Enum enumeration) =>
            $"{enumeration.GetType().Name}.{enumeration}";

        private static string Object(this Tuple<string, object> tuple) =>
            $"Tuple.Create({tuple.Item1}, {tuple.Item2})";

        private static string Object(this IEnumerable<int> ints) => ints.Any() ?
           $"new[] {{ {string.Join(", ", ints)} }}" : "Array.Empty<int>()";

        private static string Object(this IEnumerable<string> strings) =>
            strings.Any() ? $"new[] {{ {string.Join(", ", strings.Select(Object))} }}" : "Array.Empty<string>()";

        private static string Object(this IEnumerable<object> objects) =>
            objects.Any() ? $"new[] {{ {string.Join(", ", objects.Select(Object))} }}" : "Array.Empty<object>()";

        private static string Object(this List<int> ints) =>
            ints.Any() ? $"new List<int> {{ {string.Join(", ", ints.Select(Object))} }}" : "new List<int>()";

        private static string Object(this List<object> objects) =>
            objects.Any() ? $"new List<object> {{ {string.Join(", ", objects.Select(Object))} }}" : "new List<object>()";

        private static string Object(this IEnumerable<UnescapedValue> unescapedValues) =>
            $"new[] {{ {string.Join(", ", unescapedValues.Select(Object))} }}";

        private static string Object(this IEnumerable<ValueTuple<int, int>> tuples) => tuples.Any() ?
           $"new[] {{ {string.Join(", ", tuples)} }}" : "Array.Empty<ValueTuple<int,int>>()";

        private static string Object(this IDictionary<string, object> dict) =>
            string.Join(", ", dict.Values.Select(Object));

        private static string Object(this IDictionary<char, int> dict) =>
            $"new Dictionary<char, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Object(key)}] = {Object(dict[key])}"))} }}";

        private static string Object(this IDictionary<string, int> dict) =>
            $"new Dictionary<string, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Object(key)}] = {Object(dict[key])}"))} }}";

        private static string Object(this IDictionary<int, string[]> dict) =>
            $"new Dictionary<int, string[]> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Object(key)}] = {Object(dict[key])}"))} }}";

        private static string Object(this JArray jArray) =>
            $"new[] {{ {string.Join(", ", jArray.Select(Object))} }}";

        private static string Object(this int[,] multidimensionalArray)
        {
            IEnumerable<T> SliceRow<T>(T[,] array, int row)
            {
                for (var i = array.GetLowerBound(1); i <= array.GetUpperBound(1); i++)
                {
                    yield return array[row, i];
                }
            }
            
            return multidimensionalArray.GetLength(0) > 0
                            ? $"new[,]\r\n{{\r\n    {string.Join(",\r\n    ", Enumerable.Range(0, multidimensionalArray.GetUpperBound(0) + 1).Select(x => SliceRow(multidimensionalArray, x).ToNestedArray()))}\r\n}}"
                            : "new int[,] { }";
        }

        private static string Object(this IEnumerable<Tuple<string, object>> tuples) =>
            $"new[] {{ {string.Join(", ", tuples.Select(Object))} }}";

        private static string ToNestedArray<T>(this IEnumerable<T> enumerable) =>
            enumerable.Any() ? $"{{ {string.Join(", ", enumerable)} }}" : string.Empty;

        private static IEnumerable<string> FormatMultiLineString(string name, string str)
        {
            var strings = str.Split('\n');
            var formattedStrings = strings
                .Select((t, i) => i < strings.Length - 1
                    ? $"{Object(t + "\n")} +"
                    : $"{Object(t)}");

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