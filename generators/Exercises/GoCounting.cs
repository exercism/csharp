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
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.UseVariablesForConstructorParameters = true;
            canonicalDataCase.UseVariableForTested = true;

            canonicalDataCase.Input["board"] = ConvertHelper.ToMultiLineString(canonicalDataCase.Input["board"]);
            canonicalDataCase.SetConstructorInputParameters("board");

            if (canonicalDataCase.Property == "territory")
            {
                canonicalDataCase.Input["coordinate"] = (canonicalDataCase.Input["x"], canonicalDataCase.Input["y"]);
                canonicalDataCase.SetInputParameters("coordinate");

                if (canonicalDataCase.Expected.ContainsKey("error"))
                {
                    canonicalDataCase.ExceptionThrown = typeof(ArgumentException);
                }
                else
                {
                    var owner = FormatOwner(canonicalDataCase.Expected["owner"]);
                    var territory = FormatTerritory(canonicalDataCase.Expected["territory"]);
                    canonicalDataCase.Expected = (new UnescapedValue(owner), territory);
                }
            }
            else
            {
                var expected = new[]
                    {
                        "new Dictionary<Owner, ValueTuple<int,int>[]>",
                        "{",
                        $"    [Owner.Black] = {FormatTerritory(canonicalDataCase.Expected["territoryBlack"])},",
                        $"    [Owner.White] = {FormatTerritory(canonicalDataCase.Expected["territoryWhite"])},",
                        $"    [Owner.None] = {FormatTerritory(canonicalDataCase.Expected["territoryNone"])}",
                        "}"
                    };

                canonicalDataCase.Expected = new UnescapedValue(string.Join(Environment.NewLine, expected));
            }
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.CanonicalDataCase.ExceptionThrown != null)
            {
                return base.RenderTestMethodBodyAssert(testMethodBody);
            }

            if (testMethodBody.CanonicalDataCase.Property == "territories")
            {
                return string.Join(Environment.NewLine, new[]
                {
                    "Assert.Equal(expected.Keys, actual.Keys);",
                    "Assert.Equal(expected[Owner.Black], actual[Owner.Black]);",
                    "Assert.Equal(expected[Owner.White], actual[Owner.White]);",
                    "Assert.Equal(expected[Owner.None], actual[Owner.None]);"
                });
            }

            return string.Join(Environment.NewLine, new[]
            {
                "Assert.Equal(expected.Item1, actual.Item1);",
                "Assert.Equal(expected.Item2, actual.Item2);"
            });
        }

        private string FormatOwner(dynamic owner)
            => $"Owner.{(owner as string).ToLowerInvariant().Humanize()}";

        private string FormatTerritory(dynamic territory)
            => ValueFormatter.Format((territory as JArray).Select(coordinate => (coordinate[0].ToObject<int>(), coordinate[1].ToObject<int>())).ToArray());

        protected override IEnumerable<string> AdditionalNamespaces => new[]
        {
            typeof(ArgumentException).Namespace,
            typeof(Dictionary<int,int>).Namespace
        };
    }
}