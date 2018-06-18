using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class ComplexNumbers : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Exercise = "complex-number";
                canonicalDataCase.UseVariableForExpected = IsComplexNumber(canonicalDataCase.Expected);
                canonicalDataCase.Expected = ConvertToType(canonicalDataCase.Expected);

                var constructorParamName = canonicalDataCase.Input.ContainsKey("z") ? "z" : "z1";
                canonicalDataCase.Input["real"] = ConvertMathDouble(canonicalDataCase.Input[constructorParamName][0]);
                canonicalDataCase.Input["imaginary"] = ConvertMathDouble(canonicalDataCase.Input[constructorParamName][1]);

                canonicalDataCase.SetInputParameters(GetInputParameters(canonicalDataCase, constructorParamName));
                canonicalDataCase.SetConstructorInputParameters("real", "imaginary");

                var keys = canonicalDataCase.Input.Keys.ToArray();

                foreach (var key in keys)
                    canonicalDataCase.Input[key] = ConvertToType(canonicalDataCase.Input[key]);
            }
        }

        private static string[] GetInputParameters(CanonicalDataCase canonicalDataCase, string constructorParamName)
            => canonicalDataCase.Input.Keys.Where(x => x != constructorParamName).ToArray();

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

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Math).Namespace };

        private static object ConvertToType(dynamic rawValue)
        {
            if (IsComplexNumber(rawValue))
                return new UnescapedValue($"new ComplexNumber({ValueFormatter.Format(ConvertMathDouble(rawValue[0]))}, {ValueFormatter.Format(ConvertMathDouble(rawValue[1]))})");

            return rawValue;
        }

        private static bool IsComplexNumber(object rawValue) => rawValue is int[] || rawValue is double[] || rawValue is float[] || rawValue is JArray;

        private static object ConvertMathDouble(dynamic value)
        {
            switch (value.ToString())
            {
                case "e":
                    return new UnescapedValue("Math.E");
                case "pi":
                    return new UnescapedValue("Math.PI");
                case "ln(2)":
                    return new UnescapedValue("Math.Log(2.0)");
                default:
                    return double.Parse(value.ToString());
            }
        }
    }
}