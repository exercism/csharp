using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class WordSearch : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForTested = true;
            data.UseVariableForExpected = true;
            data.UseVariablesForConstructorParameters = true;

            data.SetConstructorInputParameters("grid");

            data.Input["grid"] = ConvertHelper.ToMultiLineString(data.Input["grid"]);

            var expectedDictionary = data.Expected as IDictionary<string, dynamic>;

            var expected = new List<string>
                {
                    "new Dictionary<string, ((int, int), (int, int))?>",
                    "{"
                };

            expected.AddRange(expectedDictionary.Select((kv, i) => $"    [\"{kv.Key}\"] = {FormatPosition(kv.Value)}{(i < expectedDictionary.Count - 1 ? "," : "")}"));
            expected.Add("}");

            data.Expected = new UnescapedValue(string.Join(Environment.NewLine, expected));
        }

        
        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var expectedDictionary = testMethodBody.Data.Properties["expected"] as IDictionary<string, dynamic>;

            foreach (var kv in expectedDictionary)
                yield return RenderTestMethodBodyAssertForSearchWord(kv.Key, kv.Value);
        }

        private static string RenderTestMethodBodyAssertForSearchWord(string word, dynamic expected)
        {
            return expected == null
                ? $"Assert.Null(expected[\"{word}\"]);"
                : $"Assert.Equal(expected[\"{word}\"], actual[\"{word}\"]);";
        }

        private static string FormatPosition(dynamic position)
        {
            return position == null
                ? "null" :
                ValueFormatter.Format((FormatCoordinate(position["start"]), FormatCoordinate(position["end"])));
        }

        private static string FormatCoordinate(dynamic coordinate)
            => ValueFormatter.Format((coordinate["column"], coordinate["row"]));

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(ValueTuple<int, int>).Namespace);
            namespaces.Add(typeof(Dictionary<string, ValueTuple<int, int>>).Namespace);
        }
    }
}