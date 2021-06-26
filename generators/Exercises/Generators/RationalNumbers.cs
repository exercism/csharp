using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class RationalNumbers : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAssert(TestMethod testMethod)
        {
            switch (testMethod.Property)
            {
                case "add":
                case "sub":
                case "mul":
                case "div":
                    const string operationsWithOverloading = "add|+|sub|-|mul|*|div|/";
                    var operationCode = operationsWithOverloading.Substring(operationsWithOverloading.IndexOf(testMethod.Property, StringComparison.OrdinalIgnoreCase) + 4, 1);
                    return Render.AssertEqual(RenderRationalNumber(testMethod.Expected), $"{RenderRationalNumber(testMethod.Input["r1"])} {operationCode} ({RenderRationalNumber(testMethod.Input["r2"])})");
                case "abs":
                case "reduce":
                    return Render.AssertEqual(RenderRationalNumber(testMethod.Expected), $"{RenderRationalNumber(testMethod.Input["r"])}.{testMethod.TestedMethod}()");
                case "exprational":
                    return Render.AssertEqual(RenderRationalNumber(testMethod.Expected), $"{RenderRationalNumber(testMethod.Input["r"])}.{testMethod.TestedMethod}({testMethod.Input["n"]})");
                case "expreal":
                    return Render.AssertEqualWithin(Render.Object(testMethod.Expected), $"{testMethod.Input["x"]}.{testMethod.TestedMethod}({RenderRationalNumber(testMethod.Input["r"])})", 7);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string RenderRationalNumber(dynamic input) => $"new RationalNumber({input[0]}, {input[1]})";
    }
}