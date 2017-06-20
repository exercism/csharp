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
                case Enum e:
                    return $"{e.GetType().Name}.{e}";
                case string s:
                    return $"\"{s.EscapeControlCharacters()}\"";
                default:
                    return val;
            }
        }

        private static string EscapeControlCharacters(this string s) 
            => s.Replace("\n", "\\n")
                .Replace("\t", "\\t")
                .Replace("\r", "\\r");
    }
}