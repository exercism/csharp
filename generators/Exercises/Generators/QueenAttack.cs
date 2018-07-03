using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;

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

        private string RenderAssert(TestMethod method)
        {
            if (method.Data.Property == "canAttack")
                return RenderCanAttackAssert(method);

            return method.Data.UseVariableForTested
                ? string.Empty
                : method.Assert;
        }

        private string RenderCanAttackAssert(TestMethod method)
        {
            var assert = new StringBuilder();
            
            var (whiteQueenX, whiteQueenY) = GetCoordinatesFromPosition((IDictionary<string, dynamic>)method.Data.Input["white_queen"]);
            var (blackQueenX, blackQueenY) = GetCoordinatesFromPosition((IDictionary<string, dynamic>)method.Data.Input["black_queen"]);

            assert.AppendLine(Render.Variable("whiteQueen", $"QueenAttack.Create({whiteQueenX},{whiteQueenY})"));
            assert.AppendLine(Render.Variable("blackQueen", $"QueenAttack.Create({blackQueenX},{blackQueenY})"));
            assert.AppendLine(Render.AssertBoolean((bool)method.Data.Expected, "QueenAttack.CanAttack(whiteQueen, blackQueen)"));

            return assert.ToString();
        }

        private static ValueTuple<int, int> GetCoordinatesFromPosition(IDictionary<string, dynamic> expected)
        {
            var coordinates = expected["position"];
            var positionX = (int)coordinates["row"];
            var positionY = (int)coordinates["column"];

            return (positionX, positionY);
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
