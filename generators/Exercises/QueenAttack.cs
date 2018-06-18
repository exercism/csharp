using Generators.Input;
using Generators.Output;
using System;

namespace Generators.Exercises
{
    public class QueenAttack : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            if (canonicalDataCase.Property == "create")
                SetCreatePropertyData(canonicalDataCase);
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.CanonicalDataCase.Property == "canAttack")
                return RenderCanAttackAssert(testMethodBody);

            if (testMethodBody.UseVariableForTested)
                return string.Empty;

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

        private static Tuple<int, int> GetCoordinatesFromPosition(dynamic expected)
        {
            var coordinates = expected["position"];

            var positionX = (int)coordinates["row"];
            var positionY = (int)coordinates["column"];

            return Tuple.Create(positionX, positionY);
        }

        private static void SetCreatePropertyData(CanonicalDataCase canonicalDataCase)
        {
            var validExpected = canonicalDataCase.Expected >= 0;

            canonicalDataCase.UseVariableForTested = validExpected;
            canonicalDataCase.ExceptionThrown = validExpected ? null : typeof(ArgumentOutOfRangeException);
            canonicalDataCase.Description = validExpected ? canonicalDataCase.Description + " does not throw exception" : canonicalDataCase.Description;

            var coordinates = GetCoordinatesFromPosition(canonicalDataCase.Input["queen"]);
            canonicalDataCase.Input["X"] = coordinates.Item1;
            canonicalDataCase.Input["Y"] = coordinates.Item2;

            canonicalDataCase.SetInputParameters("X", "Y");
        }
    }
}
