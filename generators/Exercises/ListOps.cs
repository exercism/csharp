using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class ListOps : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseFullDescriptionPath = true;
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = !(canonicalDataCase.Expected is int);

                if (canonicalDataCase.Input.TryGetValue("list", out var list))
                    canonicalDataCase.Input["list"] = ConvertToList(list);

                if (canonicalDataCase.Input.TryGetValue("list1", out var list1))
                    canonicalDataCase.Input["list1"] = ConvertToList(list1);

                if (canonicalDataCase.Input.TryGetValue("list2", out var list2))
                    canonicalDataCase.Input["list2"] = ConvertToList(list2);

                if (canonicalDataCase.Input.TryGetValue("lists", out var lists))
                    canonicalDataCase.Input["lists"] = ConvertToNestedList(lists, true);

                if (canonicalDataCase.Input.TryGetValue("function", out var function))
                    canonicalDataCase.Input["function"] = ConvertToFunction(canonicalDataCase.Property, function);

                if (canonicalDataCase.Expected is IEnumerable)
                {
                    if (canonicalDataCase.Input.ContainsKey("lists"))
                        canonicalDataCase.Expected = ConvertToNestedList(canonicalDataCase.Expected, false);
                    else
                        canonicalDataCase.Expected = ConvertToList(canonicalDataCase.Expected);
                }
            }
        }

        private static UnescapedValue ConvertToFunction(string property, dynamic function)
        {
            var signature =
                property == "filter" ? "<int, bool>" :
                property == "map" ? "<int, int>" :
                "<int, int, int>";

            var body = function
                .Replace("modulo", "%")
                .Replace("->", "=>");

            return new UnescapedValue($"new Func{signature}({body})");
        }

        private static dynamic ConvertToList(dynamic value)
        {
            if (value is JArray jArray)
            {
                if (jArray.Count == 0)
                    return new List<int>();

                if (jArray.Any(jToken => jToken.Type == JTokenType.Array))
                    return jArray.Select(ConvertToList).ToList();

                return jArray.ToObject<int[]>().ToList();
            }

            if (value is IEnumerable<int> ints)
            {
                return ints.ToList();
            }

            return value;
        }

        private static dynamic ConvertToNestedList(dynamic value, bool unescapeEmpty)
        {
            if (value is JArray jArray)
            {
                if (jArray.Count == 0)
                {
                    if (unescapeEmpty)
                    {
                        return new UnescapedValue("new List<List<int>>()");
                    }

                    return new List<int>();
                }

                var nestedList = jArray
                    .Children<JArray>()
                    .Select(ConvertToList)
                    .Select(ValueFormatter.Format)
                    .Select(formattedValue => new UnescapedValue(formattedValue))
                    .ToList();

                return new UnescapedValue(ValueFormatter.Format(nestedList)
                    .Replace("<object>", "<int>")
                    .Replace("new List<int> { new List<int>", "new List<List<int>> { new List<int>")
                    .Replace("new[] { new List<List<int>>", "new List<List<List<int>>> { new List<List<int>>")
                    .Replace("new[] { new List<int>", "new List<List<int>> { new List<int>"));
            }

            if (value is IEnumerable<int> ints)
            {
                return new UnescapedValue(ValueFormatter.Format(ints.ToList()));
            }

            return value;
        }

        protected override IEnumerable<string> AdditionalNamespaces() => new[]
        {
            typeof(Func<int,int>).Namespace,
            typeof(List<int>).Namespace
        };
    }
}