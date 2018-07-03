using System;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RationalNumbers : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private string RenderAssert(TestMethod method)
        {
            switch (method.Data.Property)
            {
                case "add":
                case "sub":
                case "mul":
                case "div":
                    const string operationsWithOverloading = "add|+|sub|-|mul|*|div|/";
                    var operationCode = operationsWithOverloading.Substring(operationsWithOverloading.IndexOf(method.Data.Property, StringComparison.OrdinalIgnoreCase) + 4, 1);
                    return Render.AssertEqual(RenderRationalNumber(method.Data.Expected), $"{RenderRationalNumber(method.Data.Input["r1"])} {operationCode} ({RenderRationalNumber(method.Data.Input["r2"])})");
                case "abs":
                case "reduce":
                    return Render.AssertEqual(RenderRationalNumber(method.Data.Expected), $"{RenderRationalNumber(method.Data.Input["r"])}.{method.Data.TestedMethod}()");
                case "exprational":
                    return Render.AssertEqual(RenderRationalNumber(method.Data.Expected), $"{RenderRationalNumber(method.Data.Input["r"])}.{method.Data.TestedMethod}({method.Data.Input["n"]})");
                case "expreal":
                    return Render.AssertEqual(method.ExpectedParameter, $"{method.Data.Input["x"]}.{method.Data.TestedMethod}({RenderRationalNumber(method.Data.Input["r"])}), {Precision(method.Data.Expected)}");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string RenderRationalNumber(dynamic input) => $"new RationalNumber({input[0]}, {input[1]})";

        private static int Precision(object rawValue)
            => rawValue.ToString().Split(new[] { '.' }).Length <= 1
                    ? 0
                    : rawValue.ToString().Split(new[] { '.' })[1].Length;
    }
}