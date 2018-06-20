using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class GoCounting : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
            data.UseVariablesForConstructorParameters = true;
            data.UseVariableForTested = true;

            data.Input["board"] = ConvertHelper.ToMultiLineString(data.Input["board"]);
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

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.Data.ExceptionThrown != null)
            {
                return base.RenderTestMethodBodyAssert(testMethodBody);
            }

            if (testMethodBody.Data.Property == "territories")
            {
                return new[]
                {
                    "Assert.Equal(expected.Keys, actual.Keys);",
                    "Assert.Equal(expected[Owner.Black], actual[Owner.Black]);",
                    "Assert.Equal(expected[Owner.White], actual[Owner.White]);",
                    "Assert.Equal(expected[Owner.None], actual[Owner.None]);"
                };
            }

            return new[]
            {
                "Assert.Equal(expected.Item1, actual.Item1);",
                "Assert.Equal(expected.Item2, actual.Item2);"
            };
        }

        private static string FormatOwner(dynamic owner)
            => $"Owner.{(owner as string).ToLowerInvariant().Humanize()}";

        private static string FormatTerritory(dynamic territory)
            => ValueFormatter.Format((territory as JArray).Select(coordinate => (coordinate[0].ToObject<int>(), coordinate[1].ToObject<int>())).ToArray());

        protected override IEnumerable<string> AdditionalNamespaces => new[]
        {
            typeof(ArgumentException).Namespace,
            typeof(Dictionary<int,int>).Namespace
        };
    }
}