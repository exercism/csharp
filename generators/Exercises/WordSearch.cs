using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class WordSearch : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForTested = true;
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.UseVariablesForConstructorParameters = true;

                canonicalDataCase.SetConstructorInputParameters("grid");

                canonicalDataCase.Input["grid"] = ConvertHelper.ToMultiLineString(canonicalDataCase.Input["grid"]);

                var expectedDictionary = canonicalDataCase.Expected as IDictionary<string, dynamic>;

                var expected = new List<string>
                    {
                        "new Dictionary<string, ((int, int), (int, int))?>",
                        "{"
                    };

                expected.AddRange(expectedDictionary.Select(((kv, i) => $"    [\"{kv.Key}\"] = {FormatPosition(kv.Value)}{(i < expectedDictionary.Count - 1 ? "," : "")}")));
                expected.Add("}");

                canonicalDataCase.Expected = new UnescapedValue(string.Join("\n", expected));
            }
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var expectedDictionary = testMethodBody.CanonicalDataCase.Properties["expected"] as IDictionary<string, dynamic>;

            var assert = new List<string>();

            foreach (var kv in expectedDictionary)
            {
                assert.Add(RenderTestMethodBodyAssertForSearchWord(kv.Key, kv.Value));
            }

            return string.Join("\n", assert);
        }

        private string RenderTestMethodBodyAssertForSearchWord(string word, dynamic expected)
        {
            if (expected == null)
            {
                return $"Assert.Null(expected[\"{word}\"]);";
            }

            return $"Assert.Equal(expected[\"{word}\"], actual[\"{word}\"]);";
        }

        private string FormatPosition(dynamic position)
        {
            if (position == null)
            {
                return "null";
            }

            return ValueFormatter.Format((FormatCoordinate(position["start"]), FormatCoordinate(position["end"])));
        }

        private string FormatCoordinate(dynamic coordinate)
            => ValueFormatter.Format((coordinate["column"], coordinate["row"]));

        protected override IEnumerable<string> AdditionalNamespaces() => new[]
        {
            typeof(ValueTuple<int,int>).Namespace,
            typeof(Dictionary<string,ValueTuple<int,int>>).Namespace
        };
    }
}