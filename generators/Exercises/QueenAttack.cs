﻿using System;
using System.Collections.Generic;
using Generators.Output;
using Generators.Output.Templates;

namespace Generators.Exercises
{
    public class QueenAttack : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Property == "create")
                SetCreatePropertyData(data);
        }
        
        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.Data.Property == "canAttack")
                return new[] { RenderCanAttackAssert(testMethodBody) };

            return testMethodBody.Data.UseVariableForTested
                ? Array.Empty<string>()
                : testMethodBody.Assert;
        }

        private static string RenderCanAttackAssert(TestMethodBody testMethodBody)
        {
            const string template =
@"var whiteQueen = QueenAttack.Create({{whiteQueenX}},{{whiteQueenY}});
var blackQueen = QueenAttack.Create({{blackQueenX}},{{blackQueenY}});
Assert.{% if Expected %}True{% else %}False{% endif %}(QueenAttack.CanAttack(whiteQueen, blackQueen));";

            var whiteQueenPositions = GetCoordinatesFromPosition(testMethodBody.Data.Input["white_queen"]);
            var blackQueenPositions = GetCoordinatesFromPosition(testMethodBody.Data.Input["black_queen"]);

            var templateParameters = new
            {
                whiteQueenX = whiteQueenPositions.Item1,
                whiteQueenY = whiteQueenPositions.Item2,
                blackQueenX = blackQueenPositions.Item1,
                blackQueenY = blackQueenPositions.Item2,
                testMethodBody.Data.Expected
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
