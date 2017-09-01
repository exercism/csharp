using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Generators.Exercises
{
    public class QueenAttack : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach(var canonicalDataCase in canonicalData.Cases)
            {
                if(canonicalDataCase.Property == "create")
                {
                    SetCreatePropertyData(canonicalDataCase);
                }
            }
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.CanonicalDataCase.Property == "canAttack")
            {
                return RenderCanAttackAssert(testMethodBody);
            }

            if(testMethodBody.UseVariableForTested)
            {
                return string.Empty;
            }

            return base.RenderTestMethodBodyAssert(testMethodBody);
        }

        private static string RenderCanAttackAssert(TestMethodBody testMethodBody)
        {
            const string template =
@"var whiteQueen = QueenAttack.Create({{whiteQueenX}},{{whiteQueenY}});
var blackQueen = QueenAttack.Create({{blackQueenX}},{{blackQueenY}});
Assert.{% if Expected %}True{% else %}False{% endif %}(QueenAttack.CanAttack(whiteQueen, blackQueen));";

            var whiteQueenPositions = GetCoordinatesFromPosition(testMethodBody.CanonicalDataCase.Input["white_queen"]);
            var blackQueenPositions = GetCoordinatesFromPosition(testMethodBody.CanonicalDataCase.Input["black_queen"]);

            var templateParameters = new
            {
                whiteQueenX = whiteQueenPositions.Item1,
                whiteQueenY = whiteQueenPositions.Item2,
                blackQueenX = blackQueenPositions.Item1,
                blackQueenY = blackQueenPositions.Item2,
                Expected = testMethodBody.CanonicalDataCase.Expected
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }

        private static Tuple<int, int> GetCoordinatesFromPosition(object rawPosition)
        {
            var coordinates = ((JObject)rawPosition).ToObject<Dictionary<string, string>>()["position"].Split(',');

            var positionX = int.Parse(coordinates[0].TrimStart('('));
            var positionY = int.Parse(coordinates[1].TrimEnd(')'));

            return Tuple.Create(positionX, positionY);
        }

        private static void SetCreatePropertyData(CanonicalDataCase canonicalDataCase)
        {
            var validExpected = (long)canonicalDataCase.Expected >= 0;

            canonicalDataCase.ExceptionThrown = validExpected ? null : typeof(ArgumentOutOfRangeException);
            canonicalDataCase.UseVariableForTested = validExpected;

            var coordinates = GetCoordinatesFromPosition(canonicalDataCase.Input["queen"]);
            canonicalDataCase.Input = new Dictionary<string, object>
            {
                ["X"] = coordinates.Item1,
                ["Y"] = coordinates.Item2
            };
        }
    }
}
