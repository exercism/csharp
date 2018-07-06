using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class QueenAttack : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Property == "create")
            {
                if (testMethod.Expected < 0)
                {
                    testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
                }
                else
                {
                    testMethod.UseVariableForTested = true;
                    testMethod.Assert = string.Empty;
                }

                var coordinates = GetCoordinatesFromPosition(testMethod.Input["queen"]);
                testMethod.Input["X"] = coordinates.Item1;
                testMethod.Input["Y"] = coordinates.Item2;

                testMethod.InputParameters = new[] { "X", "Y" };
                return;
            }
            
            if (testMethod.Property == "canAttack")
            {
                testMethod.UseVariablesForInput = true;
                testMethod.Input["white_queen"] = RenderQueen(testMethod.Input["white_queen"]);
                testMethod.Input["black_queen"] = RenderQueen(testMethod.Input["black_queen"]);
            }
        }
        
        private static UnescapedValue RenderQueen(dynamic input)
        {
            var (x, y) = GetCoordinatesFromPosition((IDictionary<string, dynamic>)input);
            return new UnescapedValue($"QueenAttack.Create({x},{y})");
        }

        private static (int, int) GetCoordinatesFromPosition(IDictionary<string, dynamic> expected)
        {
            var coordinates = expected["position"];
            var positionX = (int)coordinates["row"];
            var positionY = (int)coordinates["column"];

            return (positionX, positionY);
        }
    }
}
