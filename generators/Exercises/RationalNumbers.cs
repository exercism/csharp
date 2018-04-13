using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class RationalNumbers : GeneratorExercise
    {
        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.CanonicalDataCase.Expected.GetType().Name.Equals("Double"))
			     return RenderRationalNumberAssert(testMethodBody);
            return base.RenderTestMethodBodyAssert(testMethodBody);
        }

        private static string RenderRationalNumberAssert(TestMethodBody testMethodBody)
        {		
            const string template = "Assert.Equal({{ ExpectedParameter }}, {{ TestedValue }}, precision: [precision]);";
            return TemplateRenderer.RenderInline(template.Replace("[precision]", precision(testMethodBody.CanonicalDataCase.Properties["expected"]).ToString()),
			                 testMethodBody.AssertTemplateParameters);
        }
				
	private static int precision(object rawValue) => 
             rawValue.ToString().Split(new char[] {'.'}).Length == 1? 0 : rawValue.ToString().Split(new char[] {'.'})[1].Length;
    }
}