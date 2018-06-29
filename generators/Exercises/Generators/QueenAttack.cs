using System;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Exercises.Generators
{
    public class QueenAttack : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Property == "create")
                SetCreatePropertyData(data);
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method)
        {
            if (method.Data.Property == "canAttack")
                return RenderCanAttackAssert(method);

            return method.Data.UseVariableForTested
                ? string.Empty
                : method.Assert;
        }

        private static string RenderCanAttackAssert(TestMethod method)
        {
            const string template =
@"var whiteQueen = QueenAttack.Create({{whiteQueenX}},{{whiteQueenY}});
var blackQueen = QueenAttack.Create({{blackQueenX}},{{blackQueenY}});
Assert.{% if Expected %}True{% else %}False{% endif %}(QueenAttack.CanAttack(whiteQueen, blackQueen));";

            var whiteQueenPositions = GetCoordinatesFromPosition(method.Data.Input["white_queen"]);
            var blackQueenPositions = GetCoordinatesFromPosition(method.Data.Input["black_queen"]);

            var templateParameters = new
            {
                whiteQueenX = whiteQueenPositions.Item1,
                whiteQueenY = whiteQueenPositions.Item2,
                blackQueenX = blackQueenPositions.Item1,
                blackQueenY = blackQueenPositions.Item2,
                method.Data.Expected
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

        private static void SetCreatePropertyData(TestData canonicalDataCase)
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
