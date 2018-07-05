using System;
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
                data.Input["lists"] = ConvertToNestedList(lists);

            if (data.Input.TryGetValue("function", out var function))
                data.Input["function"] = ConvertToFunction(data.Property, function);

            if (data.Expected is IEnumerable)
            {
                data.Expected = ConvertToList(data.Expected);
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
            if (IsArrayOfIntegers(value))
                return new List<int>(value);
            
            if (IsListOfIntegers(value))
                return value.ToObject<List<int>>();
            
            if (IsListOfListOfIntegers(value))
                return value.ToObject<List<List<int>>>();
            
            if (IsListOfListOfListOfIntegers(value))
                return value.ToObject<List<List<List<int>>>>();
            
            throw new ArgumentException("Unsupported list type");
        }

        private static dynamic ConvertToNestedList(dynamic value) 
            => IsEmptyList(value) 
                ? new List<List<int>>() 
                : ConvertToList(value);

        private static bool IsArrayOfIntegers(dynamic value) 
            => value is int [];
        
        private static bool IsListOfIntegers(dynamic value) 
            => value is JArray jArray && jArray.All(child => child.Type == JTokenType.Integer);

        private static bool IsListOfListOfIntegers(dynamic value) 
            => value is JArray jArray && jArray.All(IsListOfIntegers);

        private static bool IsListOfListOfListOfIntegers(dynamic value) 
            => value is JArray jArray && jArray.All(IsListOfListOfIntegers);
        
        private static bool IsEmptyList(dynamic value) 
            => value is JArray jArray && jArray.Count == 0;

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Func<int,int>).Namespace);
            namespaces.Add(typeof(List<int>).Namespace);
        }
    }
}