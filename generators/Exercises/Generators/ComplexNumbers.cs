using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
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

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method)
        {
            return method.Data.UseVariableForExpected
                ? RenderComplexNumberAssert(method)
                : method.Assert;
        }

        private static string RenderComplexNumberAssert(TestMethod method)
        {
            const string template = "Assert.Equal({{ ExpectedParameter }}.Real(), {{ TestedValue }}.Real(), precision: 15);\r\nAssert.Equal({{ ExpectedParameter }}.Imaginary(), {{ TestedValue }}.Imaginary(), precision: 15);";

            return TemplateRenderer.RenderInline(template, new { method.ExpectedParameter, method.TestedValue });
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Math).Namespace);
        }

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