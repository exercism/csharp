using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class ComplexNumbers : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            canonicalData.Exercise = "complex-number";

            // Ensure the Real and Imaginary methods are tested first as they're used later to assert equality between complex numbers
            canonicalData.Cases = canonicalData.Cases.OrderBy(c => c.Property == "real" || c.Property == "imaginary" ? 0 : 1).ToArray();

            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                // Process expected
                if (IsComplexNumber(canonicalDataCase.Expected))
                {
                    canonicalDataCase.UseVariableForExpected = true;
                }

                canonicalDataCase.Expected = ConvertToType(canonicalDataCase.Expected);

                // Process constructor param
                var constructorParamName = canonicalDataCase.Input.ContainsKey("input") ? "input" : "z1";

                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["real"] = ConvertMathDouble(canonicalDataCase.Input[constructorParamName][0]),
                    ["imaginary"] = ConvertMathDouble(canonicalDataCase.Input[constructorParamName][1])
                };

                canonicalDataCase.Input.Remove(constructorParamName);

                // Process function param
                var keys = canonicalDataCase.Input.Keys.ToArray();

                foreach (var key in keys)
                {
                    canonicalDataCase.Input[key] = ConvertToType(canonicalDataCase.Input[key]);
                }
            }
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.UseVariableForExpected)
                return RenderComplexNumberAssert(testMethodBody);

            return base.RenderTestMethodBodyAssert(testMethodBody);
        }

        private static string RenderComplexNumberAssert(TestMethodBody testMethodBody)
        {
            const string template = "Assert.Equal({{ ExpectedParameter }}.Real(), {{ TestedValue }}.Real(), precision: 15);\r\nAssert.Equal({{ ExpectedParameter }}.Imaginary(), {{ TestedValue }}.Imaginary(), precision: 15);";

            return TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters);
        }

        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string>
        {
            typeof(Math).Namespace
        };

        private static object ConvertToType(dynamic rawValue)
        {
            if (IsComplexNumber(rawValue))
                return new UnescapedValue($"new ComplexNumber({ConvertMathDouble(rawValue[0])}, {rawValue[1]})");

            return rawValue;
        }

        private static bool IsComplexNumber(object rawValue) => rawValue is JArray;

        private static object ConvertMathDouble(dynamic value)
        {
            switch (value.ToString())
            {
                case "e":
                    return new UnescapedValue("Math.E");
                case "pi":
                    return new UnescapedValue("Math.PI");
                default:
                    return (double)value;
            }
        }
    }
}