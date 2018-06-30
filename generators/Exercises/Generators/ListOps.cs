﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class ListOps : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseFullDescriptionPath = true;
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = !(data.Expected is int);

            if (data.Input.TryGetValue("list", out var list))
                data.Input["list"] = ConvertToList(list);

            if (data.Input.TryGetValue("list1", out var list1))
                data.Input["list1"] = ConvertToList(list1);

            if (data.Input.TryGetValue("list2", out var list2))
                data.Input["list2"] = ConvertToList(list2);

            if (data.Input.TryGetValue("lists", out var lists))
                data.Input["lists"] = ConvertToNestedList(lists, true);

            if (data.Input.TryGetValue("function", out var function))
                data.Input["function"] = ConvertToFunction(data.Property, function);

            if (data.Expected is IEnumerable)
            {
                data.Expected = data.Input.ContainsKey("lists")
                    ? ConvertToNestedList(data.Expected, false)
                    : ConvertToList(data.Expected);
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
            switch (value)
            {
                case JArray jArray when jArray.Count == 0:
                    return new List<int>();
                case JArray jArray when jArray.Any(jToken => jToken.Type == JTokenType.Array):
                    return jArray.Select(ConvertToList).ToList();
                case JArray jArray:
                    return jArray.ToObject<int[]>().ToList();
                case IEnumerable<int> ints:
                    return ints.ToList();
            }

            return value;
        }

        private dynamic ConvertToNestedList(dynamic value, bool unescapeEmpty)
        {
            switch (value)
            {
                case JArray jArray when jArray.Count == 0:
                    if (unescapeEmpty)
                    {
                        return new UnescapedValue("new List<List<int>>()");
                    }

                    return new List<int>();
                case JArray jArray:
                    var nestedList = jArray
                        .Children<JArray>()
                        .Select(ConvertToList)
                        .Select(Render.Object)
                        .Select(renderedValue => new UnescapedValue(renderedValue))
                        .ToList();

                    return new UnescapedValue(Render.Object(nestedList)
                        .Replace("<object>", "<int>")
                        .Replace("new List<int> { new List<int>", "new List<List<int>> { new List<int>")
                        .Replace("new[] { new List<List<int>>", "new List<List<List<int>>> { new List<List<int>>")
                        .Replace("new[] { new List<int>", "new List<List<int>> { new List<int>"));
                case IEnumerable<int> ints:
                    return new UnescapedValue(Render.Object(ints.ToList()));
            }

            return value;
        }
        
        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Func<int,int>).Namespace);
            namespaces.Add(typeof(List<int>).Namespace);
        }
    }
}