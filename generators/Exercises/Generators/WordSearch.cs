using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class WordSearch : GeneratorExercise
    {
        private IDictionary<string, dynamic> _expectedDictionary;

        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForTested = true;
            data.UseVariableForExpected = true;
            data.UseVariablesForConstructorParameters = true;

            data.SetConstructorInputParameters("grid");

            data.Input["grid"] = new MultiLineString(data.Input["grid"]);

            _expectedDictionary = (IDictionary<string, dynamic>)data.Expected;

            var expected = new List<string>
                {
                    "new Dictionary<string, ((int, int), (int, int))?>",
                    "{"
                };

            expected.AddRange(_expectedDictionary.Select((kv, i) => $"    [\"{kv.Key}\"] = {RenderPosition(kv.Value)}{(i < _expectedDictionary.Count - 1 ? "," : "")}"));
            expected.Add("}");

            data.Expected = new UnescapedValue(string.Join(Environment.NewLine, expected));
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert();
        }

        private string RenderAssert()
            => string.Join(Environment.NewLine, _expectedDictionary
                    .Select(kv => RenderAssertForSearchWord(kv.Key, kv.Value))
                    .Cast<string>());

        private string RenderAssertForSearchWord(string word, dynamic expected) 
            => expected == null
                ? Render.AssertNull($"expected[\"{word}\"]")
                : Render.AssertEqual($"expected[\"{word}\"]", $"actual[\"{word}\"]");

        private string RenderPosition(dynamic position) 
            => position == null
                ? "null" :
                Render.Object((RenderCoordinate(position["start"]), RenderCoordinate(position["end"])));

        private string RenderCoordinate(dynamic coordinate)
            => Render.Object((coordinate["column"], coordinate["row"]));

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(ValueTuple<int, int>).Namespace);
            namespaces.Add(typeof(Dictionary<string, ValueTuple<int, int>>).Namespace);
        }
    }
}