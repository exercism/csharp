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
                case IDictionary<string, object> dict:
                    return string.Join(", ", dict.Values.Select(Format));
                case IDictionary<char, int> dict:
                    return $"new Dictionary<char, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Format(key)}] = {Format(dict[key])}"))} }}";
                case IDictionary<string, int> dict:
                    return $"new Dictionary<string, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Format(key)}] = {Format(dict[key])}"))} }}";
                case Enum enumeration:
                    return $"{enumeration.GetType().Name}.{enumeration}";
                case JArray jArray:
                    return $"new[] {{ {string.Join(", ", jArray.Select(Format))} }}";
                case string str:
                    return str.FormatString();
                case IEnumerable<int> ints:
                    return ints.Any() ? $"new[] {{ {string.Join(", ", ints)} }}" : "new int[0]";
                case IEnumerable<string> strings:
                    return strings.Any() ? $"new[] {{ {string.Join(", ", strings.Select(Format) )} }}" : "new string[0]";
                case double dbl:
                    return dbl.ToString(CultureInfo.InvariantCulture);
                case float flt:
                    return flt.ToString(CultureInfo.InvariantCulture);
                case ulong ulng:
                    return $"{ulng}UL";
                case char c:
                    return $"'{c}'";
                default:
                    return val;
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
                    return new[] {$"var {name} = {Format(val)};"};
            }
        }

        private static string FormatString(this string s) => s.EscapeSpecialCharacters().Quote();

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
        
        private static IEnumerable<string> AddTrailingSemicolon(this IEnumerable<string> enumerable)
        {
            var array = enumerable.ToArray();
            array[array.Length - 1] += ";";
            return array;
        }
    }
}