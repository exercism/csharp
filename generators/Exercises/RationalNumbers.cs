using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;
using Humanizer;

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
            string template = "Assert.Equal([expression]);";
			string expression = "";
			
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
                       expression = $"new RationalNumber ({e.Numerator},{e.Denominator}), new RationalNumber({r1.Numerator},{r1.Denominator}).{operationName}(new RationalNumber({r2.Numerator},{r2.Denominator}))";
					}
                    break;
                case "abs":
                case "reduce":
                    {
                        var r = new RationalNumber((int[])input["r"]);
                        var e = new RationalNumber((int[])expected);						
                        expression = $"new RationalNumber ({e.Numerator},{e.Denominator}), new RationalNumber({r.Numerator},{r.Denominator}).{operationName}()";
                    }
                    break;
                case "exprational":
                    {
                        var r = new RationalNumber((int[])input["r"]);
                        var n = input["n"];
                        var e = new RationalNumber((int[])expected);						
                        expression = $"new RationalNumber ({e.Numerator},{e.Denominator}), new RationalNumber({r.Numerator},{r.Denominator}).{operationName}({n})";
                    }
                    break;
                case "expreal":
                    {
                        var x = input["x"].ToString();
                        var r = new RationalNumber((int[])input["r"]);
                        var e = expected;
                        var p = precision(e);						
                        expression = $"{e}, {x}.{operationName}(new RationalNumber({r.Numerator},{r.Denominator})),{p}";						
                    }
                    break;
            }
			return TemplateRenderer.RenderInline(template.Replace("[expression]", expression), testMethodBody.AssertTemplateParameters);			
        }

        private static int precision(object rawValue) =>
                 rawValue.ToString().Split(new char[] { '.' }).Length == 1 ? 0 : rawValue.ToString().Split(new char[] { '.' })[1].Length;
    }
}