using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exercism.CSharp.Output;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class GoCounting : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
            data.UseVariablesForConstructorParameters = true;
            data.UseVariableForTested = true;

            data.Input["board"] = new MultiLineString(data.Input["board"]);
            data.SetConstructorInputParameters("board");

            if (data.Property == "territory")
            {
                data.Input["coordinate"] = (data.Input["x"], data.Input["y"]);
                data.SetInputParameters("coordinate");

                if (data.Expected.ContainsKey("error"))
                {
                    data.ExceptionThrown = typeof(ArgumentException);
                }
                else
                {
                    var owner = FormatOwner(data.Expected["owner"]);
                    var territory = FormatTerritory(data.Expected["territory"]);
                    data.Expected = (new UnescapedValue(owner), territory);
                }
            }
            else
            {
                var expected = new[]
                    {
                        "new Dictionary<Owner, ValueTuple<int,int>[]>",
                        "{",
                        $"    [Owner.Black] = {FormatTerritory(data.Expected["territoryBlack"])},",
                        $"    [Owner.White] = {FormatTerritory(data.Expected["territoryWhite"])},",
                        $"    [Owner.None] = {FormatTerritory(data.Expected["territoryNone"])}",
                        "}"
                    };

                data.Expected = new UnescapedValue(string.Join(Environment.NewLine, expected));
            }
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method)
        {
            if (method.Data.ExceptionThrown != null)
            {
                return method.Assert;
            }

            if (method.Data.Property == "territories")
            {
                var territoriesAssert = new StringBuilder();
                territoriesAssert.AppendLine("Assert.Equal(expected.Keys, actual.Keys);");
                territoriesAssert.AppendLine("Assert.Equal(expected[Owner.Black], actual[Owner.Black]);");
                territoriesAssert.AppendLine("Assert.Equal(expected[Owner.White], actual[Owner.White]);");
                territoriesAssert.AppendLine("Assert.Equal(expected[Owner.None], actual[Owner.None]);");
                return territoriesAssert.ToString();
            }

            var assert = new StringBuilder();
            assert.AppendLine("Assert.Equal(expected.Item1, actual.Item1);");
            assert.AppendLine("Assert.Equal(expected.Item2, actual.Item2);");
            return assert.ToString();
        }

        private static string FormatOwner(dynamic owner)
            => $"Owner.{(owner as string).ToLowerInvariant().Humanize()}";

        private static string FormatTerritory(dynamic territory)
            => ValueFormatter.Format((territory as JArray).Select(coordinate => (coordinate[0].ToObject<int>(), coordinate[1].ToObject<int>())).ToArray());

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Dictionary<int, int>).Namespace);
        }
    }
}