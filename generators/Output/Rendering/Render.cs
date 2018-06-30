using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Exercism.CSharp.Helpers;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {   
        public string Object(object val)
        {
            switch (val)
            {
                case string str: return String(str);
                case MultiLineString multiLineString: return String(multiLineString.ToString());
                case double dbl: return Double(dbl);
                case int i: return Int(i);
                case float flt: return Float(flt);
                case ulong ulng: return Ulong(ulng);
                case char c: return Char(c);
                case Tuple<string, object> tuple: return Object(tuple);
                case List<int> ints: return Object(ints);
                case List<object> objects: return Object(objects);
                case IEnumerable<int> ints: return Object(ints);
                case IEnumerable<string> strings: return Object(strings);
                case IEnumerable<UnescapedValue> unescapedValues when unescapedValues.Any(): return Object(unescapedValues);
                case IDictionary<string, object> dict: return Object(dict);
                case IDictionary<char, int> dict: return Object(dict);
                case IDictionary<string, int> dict: return Object(dict);
                case IDictionary<int, string[]> dict: return Object(dict);
                case JArray jArray: return Object(jArray);
                case int[,] multidimensionalArray: return Object(multidimensionalArray);
                case IEnumerable<ValueTuple<int, int>> tuples: return Object(tuples);
                case IEnumerable<Tuple<string, object>> tuples: return Object(tuples);
                case IEnumerable<object> objects: return Object(objects);
                default: return val?.ToString();
            }
        }

        public IEnumerable<string> Variables(IDictionary<string, object> dict)
            => dict.Keys.SelectMany(key => Variable(dict[key], key.ToVariableName())).ToArray();

        public IEnumerable<string> Variable(object val, string name)
        {
            switch (val)
            {
                case string str when str.Contains("\n"):
                    return MultiLineString(name, str);
                case MultiLineString multiLineValue when multiLineValue.ToString().Contains("\n"):
                    return MultiLineString(name, multiLineValue.ToString());
                case IEnumerable<string> strings:
                    if (!strings.Any())
                    {
                        return new[] { $"var {name} = Array.Empty<string>();" };
                    }

                    return MultiLineEnumerable(strings.Select((str, i) => String(str) + (i < strings.Count() - 1 ? "," : "")), name, "new[]");
                case IDictionary<char, int> dict:
                    return MultiLineEnumerable(dict.Keys.Select((key, i) => $"[{Char(key)}] = {Int(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name, "new Dictionary<char, int>");
                case IDictionary<string, int> dict:
                    return MultiLineEnumerable(dict.Keys.Select((key, i) => $"[{String(key)}] = {Int(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name, "new Dictionary<string, int>");
                case IDictionary<int, string[]> dict:
                    return MultiLineEnumerable(dict.Keys.Select((key, i) => $"[{Int(key)}] = {Object(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name, "new Dictionary<int, string[]>");
                case IEnumerable<ValueTuple<int, int>> tuples:
                    return new[] { Object(tuples) };
                default:
                    return new[] { $"var {name} = {Object(val)};" };
            }
        }

        private string Object(Tuple<string, object> tuple) =>
            $"Tuple.Create({tuple.Item1}, {tuple.Item2})";

        private string Object(IEnumerable<int> ints) => ints.Any() ?
           $"new[] {{ {string.Join(", ", ints)} }}" : "Array.Empty<int>()";

        private string Object(IEnumerable<string> strings) =>
            strings.Any() ? $"new[] {{ {string.Join(", ", strings.Select(String))} }}" : "Array.Empty<string>()";

        private string Object(IEnumerable<object> objects) =>
            objects.Any() ? $"new[] {{ {string.Join(", ", objects.Select(Object))} }}" : "Array.Empty<object>()";

        private string Object(List<int> ints) =>
            ints.Any() ? $"new List<int> {{ {string.Join(", ", ints.Select(Int))} }}" : "new List<int>()";

        private string Object(List<object> objects) =>
            objects.Any() ? $"new List<object> {{ {string.Join(", ", objects.Select(Object))} }}" : "new List<object>()";

        private string Object(IEnumerable<UnescapedValue> unescapedValues) =>
            $"new[] {{ {string.Join(", ", unescapedValues.Select(Object))} }}";

        private string Object(IEnumerable<ValueTuple<int, int>> tuples) => tuples.Any() ?
           $"new[] {{ {string.Join(", ", tuples)} }}" : "Array.Empty<ValueTuple<int,int>>()";

        private string Object(IDictionary<string, object> dict) =>
            string.Join(", ", dict.Values.Select(Object));

        private string Object(IDictionary<char, int> dict) =>
            $"new Dictionary<char, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Char(key)}] = {Int(dict[key])}"))} }}";

        private string Object(IDictionary<string, int> dict) =>
            $"new Dictionary<string, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{String(key)}] = {Int(dict[key])}"))} }}";

        private string Object(IDictionary<int, string[]> dict) =>
            $"new Dictionary<int, string[]> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Int(key)}] = {Object(dict[key])}"))} }}";

        private string Object(JArray jArray) =>
            $"new[] {{ {string.Join(", ", jArray.Select(Object))} }}";

        private string Object(int[,] multidimensionalArray)
        {
            IEnumerable<T> SliceRow<T>(T[,] array, int row)
            {
                for (var i = array.GetLowerBound(1); i <= array.GetUpperBound(1); i++)
                {
                    yield return array[row, i];
                }
            }
            
            return multidimensionalArray.GetLength(0) > 0
                            ? $"new[,]\r\n{{\r\n    {string.Join(",\r\n    ", Enumerable.Range(0, multidimensionalArray.GetUpperBound(0) + 1).Select(x => ToNestedArray(SliceRow(multidimensionalArray, x))))}\r\n}}"
                            : "new int[,] { }";
        }

        private string Object(IEnumerable<Tuple<string, object>> tuples) =>
            $"new[] {{ {string.Join(", ", tuples.Select(Object))} }}";

        private string ToNestedArray<T>(IEnumerable<T> enumerable) =>
            enumerable.Any() ? $"{{ {string.Join(", ", enumerable)} }}" : string.Empty;

        private IEnumerable<string> MultiLineString(string name, string str)
        {
            var strings = str.Split('\n');
            var renderedStrings = strings.Select((t, i) => i < strings.Length - 1
                ? $"{String(t + "\n")} +"
                : $"{String(t)}");

            return MultiLineVariable(renderedStrings, name);
        }

        private IEnumerable<string> MultiLineEnumerable(IEnumerable<string> enumerable, string name, string constructor = null)
            => MultiLineVariable(enumerable.Prepend("{").Append("}"), name, constructor);

        private IEnumerable<string> MultiLineVariable(IEnumerable<string> enumerable, string name, string constructor = null)
            => enumerable.Select(line => line == "{" || line == "}" ? line : line.Indent()).AddTrailingSemicolon().Prepend($"var {name} = {constructor}").ToArray();
    }
}