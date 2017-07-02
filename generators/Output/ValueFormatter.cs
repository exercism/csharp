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
                case Enum enumeration:
                    return $"{enumeration.GetType().Name}.{enumeration}";
                case JArray jArray:
                    return $"new[] {{ {string.Join(", ", jArray.Select(Format))} }}";
                case string str:
                    return str.FormatString();
                case IEnumerable<int> ints:
                    return ints.Any() ? $"new[] {{ {string.Join(", ", ints)} }}" : "new int[0]";
                case IEnumerable<string> strings:
                    return strings.Any() ? $"new[] {{ {string.Join(", ", strings)} }}" : "new string[0]";
                case double dbl:
                    return dbl.ToString(CultureInfo.InvariantCulture);
                case float flt:
                    return flt.ToString(CultureInfo.InvariantCulture);
                default:
                    return val;
            }
        }

        public static string[] FormatVariables(IDictionary<string, object> dict) 
            => dict.Keys.SelectMany((key, i) => FormatVariable(dict[key], key.ToVariableName())).ToArray();

        public static string[] FormatVariable(object val, string name)
        {
            switch (val)
            {
                case string str when str.Contains("\n"):
                    return FormatMultiLineString(name, str);
                case int[] ints when ints.Any():
                    return FormatMultiLineEnumerable(ints.Select(x => x.ToString(CultureInfo.InvariantCulture)), name);
                case string[] strings when strings.Any():
                    return FormatMultiLineEnumerable(strings, name);
                default:
                    return new[] {$"var {name} = {Format(val)};"};
            }
        }

        private static string FormatString(this string s) => s.EscapeControlCharacters().Quote();

        private static string[] FormatMultiLineString(string name, string str)
        {
            var strings = str.Split('\n');
            var formattedStrings = strings
                .Select((t, i) => i < strings.Length - 1
                    ? $"{Format(t + "\n")} +"
                    : $"{Format(t)}");

            return FormatMultiLineVariable(formattedStrings, name);
        }

        private static string[] FormatMultiLineEnumerable(IEnumerable<string> enumerable, string name) 
            => FormatMultiLineVariable(enumerable.Prepend("{").Append("}"), name);

        private static string[] FormatMultiLineVariable(IEnumerable<string> enumerable, string name) 
            => enumerable.Select(line => line.Indent())
                .AddTrailingSemicolon()
                .Prepend($"var {name} = ")
                .ToArray();

        private static string EscapeControlCharacters(this string s)
            => s.Replace("\n", "\\n")
                .Replace("\t", "\\t")
                .Replace("\r", "\\r");

        private static string Quote(this string s) => $"\"{s}\"";

        private static string Indent(this string s, int level = 1) => $"{new string(' ', 4 * level)}{s}";

        private static IEnumerable<string> AddTrailingSemicolon(this IEnumerable<string> enumerable)
        {
            var array = enumerable.ToArray();
            array[array.Length - 1] += ";";
            return array;
        }
    }
}