using System;
using System.Collections.Generic;
using System.Linq;

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
                    return $"{enumeration.GetType().Name}.{enumeration}";;
                case IEnumerable<string> strings:
                    return strings.Select(FormatString);
                case string str:
                    return str.FormatString();
                default:
                    return val;
            }
        }

        public static IEnumerable<string> FormatVariable(object val, string name)
        {
            switch (val)
            {
                case MultiLineString multiLineString:
                    if (!multiLineString.Any())
                        return new [] {$"var {name} = {Format("")};"};

                    var lines = new List<string> { $"var {name} = " };
                    return lines.Concat(    
                        multiLineString
                        .Select((t, i) => i < multiLineString.Count() - 1
                            ? $"    {Format(t + "\n")} +"
                            : $"    {Format(t)};"));
                default:
                    return new[] {$"var expected = {Format(val)};"};
            }
        }

        private static string FormatString(this string s) => s.EscapeControlCharacters().Quote();
        
        private static string EscapeControlCharacters(this string s)
            => s.Replace("\n", "\\n")
                .Replace("\t", "\\t")
                .Replace("\r", "\\r");

        private static string Quote(this string s) => $"\"{s}\"";
    }
}