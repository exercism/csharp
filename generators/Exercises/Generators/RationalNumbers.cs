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
        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var input = testMethodBody.Data.Properties["input"] as Dictionary<string, object>;
            var operation = testMethodBody.Data.Properties["property"].ToString();
            var expected = testMethodBody.Data.Properties["expected"];
            var operationName = char.ToUpper(operation[0]) + operation.Substring(1);
            var assertCodeLine = "";
            const string operationsWithOverloading = "add|+|sub|-|mul|*|div|/";
            string operationCode = operationsWithOverloading.Substring(operationsWithOverloading.IndexOf(operation.ToLower()) + 4, 1);

            switch (operation.ToLower())
            {
                case "add":
                case "sub":
                case "mul":
                case "div":
                    {
                        var r1 = new RationalNumber((int[])input["r1"]);
                        var r2 = new RationalNumber((int[])input["r2"]);
                        var e = new RationalNumber((int[])expected);
                        assertCodeLine = "Assert.Equal(" + $"new RationalNumber ({e.Numerator}, {e.Denominator}), new RationalNumber({r1.Numerator}, {r1.Denominator}) {operationCode} (new RationalNumber({r2.Numerator}, {r2.Denominator})));";
                    }
                    break;
                case "abs":
                case "reduce":
                    {
                        var r = new RationalNumber((int[])input["r"]);
                        var e = new RationalNumber((int[])expected);
                        assertCodeLine = "Assert.Equal(" + $"new RationalNumber ({e.Numerator}, {e.Denominator}), new RationalNumber({r.Numerator}, {r.Denominator}).{operationName}());";
                    }
                    break;
                case "exprational":
                    {
                        var r = new RationalNumber((int[])input["r"]);
                        var n = input["n"];
                        var e = new RationalNumber((int[])expected);
                        assertCodeLine = "Assert.Equal(" + $"new RationalNumber ({e.Numerator}, {e.Denominator}), new RationalNumber({r.Numerator}, {r.Denominator}).{operationName}({n}));";
                    }
                    break;
                case "expreal":
                    {
                        var x = input["x"].ToString();
                        var r = new RationalNumber((int[])input["r"]);
                        var e = ValueFormatter.Format(expected);
                        var p = Precision(e);
                        assertCodeLine = "Assert.Equal(" + $"{e}, {x}.{operationName}(new RationalNumber({r.Numerator}, {r.Denominator})), {p});";
                    }
                    break;
            }

            return new[] { TemplateRenderer.RenderInline(assertCodeLine, testMethodBody.AssertTemplateParameters) };
        }

        private static int Precision(object rawValue)
            => rawValue.ToString().Split(new[] { '.' }).Length <= 1
                    ? 0
                    : rawValue.ToString().Split(new[] { '.' })[1].Length;
    }
}