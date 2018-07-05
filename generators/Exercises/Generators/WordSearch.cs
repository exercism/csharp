using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotLiquid.Tags;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
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

            data.Input["grid"] = new MultiLineString(data.Input["grid"]);
            data.Expected = ((IDictionary<string, dynamic>)data.Expected).ToDictionary(kv => kv.Key, kv => (((int, int), (int, int))?)ConvertToPosition(kv.Value));
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private string RenderAssert(TestMethod method)
        {
            var assert = new StringBuilder();

            foreach (var kv in method.Data.Expected)
                assert.AppendLine(RenderAssertForSearchWord(kv.Key, kv.Value));

            return assert.ToString();
        }

        private string RenderAssertForSearchWord(string word, dynamic expected) 
            => expected is null
                ? Render.AssertNull($"expected[\"{word}\"]")
                : Render.AssertEqual($"expected[\"{word}\"]", $"actual[\"{word}\"]");

        private static ((int, int), (int, int))? ConvertToPosition(dynamic position)
        {
            if (position == null)
                return null;

            return (ConvertToCoordinate(position["start"]), ConvertToCoordinate(position["end"]));
        }

        private static (int, int) ConvertToCoordinate(dynamic coordinate)
            => (Convert.ToInt32(coordinate["column"]), Convert.ToInt32(coordinate["row"]));

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(ValueTuple<int, int>).Namespace);
            namespaces.Add(typeof(Dictionary<string, ValueTuple<int, int>>).Namespace);
        }
    }
}