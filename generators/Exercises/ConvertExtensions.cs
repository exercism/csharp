using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public static class ConvertExtensions
    {
        public static string ConvertMultiLineString(this object obj) => string.Join("\n", (JArray)obj);

        public static IEnumerable<T> ConvertToEnumerable<T>(this object obj) => ((JArray) obj).Values<T>();
    }
}
