using Generators.Output;

namespace Generators.Exercises
{
    public struct RationalNumber
    {
        public RationalNumber(int[] n)
        {
            this.Numerator = n[0];
            this.Denominator = n[1];
        }

        public int Numerator { get; }
        public int Denominator { get; }
    }
	
    public class RationalNumbers : GeneratorExercise
    {
        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var input = testMethodBody.CanonicalDataCase.Properties["input"] as System.Collections.Generic.Dictionary<string, object>;
            var operation = testMethodBody.CanonicalDataCase.Properties["property"].ToString();
            var expected = testMethodBody.CanonicalDataCase.Properties["expected"];
			var operationName = char.ToUpper(operation[0]) + operation.Substring(1);			
            string assertCodeLine = "";
            string operationsWithOverloading = "add|+|sub|-|mul|*|div|/";
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
                        assertCodeLine = "Assert.Equal(" + $"new RationalNumber ({e.Numerator}, {e.Denominator}), new RationalNumber({r1.Numerator}, {r1.Denominator}).{operationName}(new RationalNumber({r2.Numerator}, {r2.Denominator})));\r\n" +
                                         "Assert.Equal(" + $"new RationalNumber ({e.Numerator}, {e.Denominator}), new RationalNumber({r1.Numerator}, {r1.Denominator}) {operationCode} (new RationalNumber({r2.Numerator}, {r2.Denominator})));";
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
                        var e = expected;
                        var p = precision(e);
                        assertCodeLine = "Assert.Equal(" + $"{e}, {x}.{operationName}(new RationalNumber({r.Numerator}, {r.Denominator})),{p});";						
                    }
                    break;
            }
            return TemplateRenderer.RenderInline(assertCodeLine, testMethodBody.AssertTemplateParameters);			
        }

        private static int precision(object rawValue) =>
                 rawValue.ToString().Split(new char[] { '.' }).Length == 1 ? 0 : rawValue.ToString().Split(new char[] { '.' })[1].Length;
    }
}