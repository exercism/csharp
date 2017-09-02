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

                var constructorParamValues = canonicalDataCase.Input[constructorParamName]
                    .ConvertToEnumerable<string>()
                    .Select(v => ConvertMathDouble(v))
                    .ToArray();

                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["real"] = constructorParamValues[0],
                    ["imaginary"] = constructorParamValues[1]
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
            var tmeplate = "Assert.Equal({{ ExpectedParameter }}.Real(), {{ TestedValue }}.Real(), 15);\r\nAssert.Equal({{ ExpectedParameter }}.Imaginary(), {{ TestedValue }}.Imaginary(), 15);";

            return TemplateRenderer.RenderInline(tmeplate, testMethodBody.AssertTemplateParameters);
        }

        protected override HashSet<string> GetUsingNamespaces()
        {
            var usingNamespaces = base.GetUsingNamespaces();
            usingNamespaces.Add(typeof(Math).Namespace);

            return usingNamespaces;
        }

        private object ConvertToType(object rawValue)
        {
            if (IsComplexNumber(rawValue))
            {
                var array = rawValue
                    .ConvertToEnumerable<string>()
                    .Select(rv => ConvertToType(rv))
                    .ToArray();

                return new UnescapedValue($"new ComplexNumber({array[0]}, {array[1]})");
            }
            else if (rawValue is string)
            {
                return ConvertMathDouble((string)rawValue);
            }
            else
            {
                return rawValue;
            }
        }

        private bool IsComplexNumber(object rawValue)
        {
            return rawValue is JArray;
        }

        private object ConvertMathDouble(string value)
        {
            switch (value)
            {
                case "e":
                    return new UnescapedValue("Math.E");
                case "pi":
                    return new UnescapedValue("Math.PI");
                default:
                    return double.Parse(value);
            }
        }
    }
}