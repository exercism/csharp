using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Exercises.Generators
{
    public struct RationalNumber
    {
        public RationalNumber(IReadOnlyList<int> n)
        {
            Numerator = n[0];
            Denominator = n[1];
        }

        public int Numerator { get; }
        public int Denominator { get; }
    }

    public class RationalNumbers : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static IEnumerable<string> RenderAssert(TestMethod method)
        {
            var input = (Dictionary<string, object>)method.Data.Input;
            var operationName = char.ToUpper(method.Data.Property[0]) + method.Data.Property.Substring(1);
            var assertCodeLine = "";
            const string operationsWithOverloading = "add|+|sub|-|mul|*|div|/";
            var operationCode = operationsWithOverloading.Substring(operationsWithOverloading.IndexOf(method.Data.Property.ToLower()) + 4, 1);

            switch (method.Data.Property.ToLower())
            {
                case "add":
                case "sub":
                case "mul":
                case "div":
                    {
                        var r1 = new RationalNumber((int[])input["r1"]);
                        var r2 = new RationalNumber((int[])input["r2"]);
                        var e = new RationalNumber((int[])method.Data.Expected);
                        assertCodeLine = "Assert.Equal(" + $"new RationalNumber ({e.Numerator}, {e.Denominator}), new RationalNumber({r1.Numerator}, {r1.Denominator}) {operationCode} (new RationalNumber({r2.Numerator}, {r2.Denominator})));";
                    }
                    break;
                case "abs":
                case "reduce":
                    {
                        var r = new RationalNumber((int[])input["r"]);
                        var e = new RationalNumber((int[])method.Data.Expected);
                        assertCodeLine = "Assert.Equal(" + $"new RationalNumber ({e.Numerator}, {e.Denominator}), new RationalNumber({r.Numerator}, {r.Denominator}).{operationName}());";
                    }
                    break;
                case "exprational":
                    {
                        var r = new RationalNumber((int[])input["r"]);
                        var n = input["n"];
                        var e = new RationalNumber((int[])method.Data.Expected);
                        assertCodeLine = "Assert.Equal(" + $"new RationalNumber ({e.Numerator}, {e.Denominator}), new RationalNumber({r.Numerator}, {r.Denominator}).{operationName}({n}));";
                    }
                    break;
                case "expreal":
                    {
                        var x = input["x"].ToString();
                        var r = new RationalNumber((int[])input["r"]);
                        var e = ValueFormatter.Format(method.Data.Expected);
                        var p = Precision(e);
                        assertCodeLine = "Assert.Equal(" + $"{e}, {x}.{operationName}(new RationalNumber({r.Numerator}, {r.Denominator})), {p});";
                    }
                    break;
            }

            return new[] { assertCodeLine };
        }

        private static int Precision(object rawValue)
            => rawValue.ToString().Split(new[] { '.' }).Length <= 1
                    ? 0
                    : rawValue.ToString().Split(new[] { '.' })[1].Length;
    }
}