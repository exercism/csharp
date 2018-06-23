using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class ComplexNumbers : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedClass = "ComplexNumber";
            data.UseVariableForExpected = IsComplexNumber(data.Expected);
            data.Expected = ConvertToType(data.Expected);

            var constructorParamName = data.Input.ContainsKey("z") ? "z" : "z1";
            data.Input["real"] = ConvertMathDouble(data.Input[constructorParamName][0]);
            data.Input["imaginary"] = ConvertMathDouble(data.Input[constructorParamName][1]);

            data.SetInputParameters(GetInputParameters(data, constructorParamName));
            data.SetConstructorInputParameters("real", "imaginary");

            var keys = data.Input.Keys.ToArray();

            foreach (var key in keys)
                data.Input[key] = ConvertToType(data.Input[key]);
        }

        private static string[] GetInputParameters(TestData canonicalDataCase, string constructorParamName)
            => canonicalDataCase.Input.Keys.Where(x => x != constructorParamName).ToArray();

        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            return testMethodBody.Data.UseVariableForExpected
                ? RenderComplexNumberAssert(testMethodBody)
                : testMethodBody.Assert;
        }

        private static IEnumerable<string> RenderComplexNumberAssert(TestMethodBody testMethodBody)
        {
            const string template = "Assert.Equal({{ ExpectedParameter }}.Real(), {{ TestedValue }}.Real(), precision: 15);\r\nAssert.Equal({{ ExpectedParameter }}.Imaginary(), {{ TestedValue }}.Imaginary(), precision: 15);";

            return new[] { TemplateRenderer.RenderInline(template, testMethodBody.AssertTemplateParameters) };
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Math).Namespace };

        private static object ConvertToType(dynamic rawValue)
        {
            return IsComplexNumber(rawValue)
                ? new UnescapedValue($"new ComplexNumber({ValueFormatter.Format(ConvertMathDouble(rawValue[0]))}, {ValueFormatter.Format(ConvertMathDouble(rawValue[1]))})")
                : rawValue;
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