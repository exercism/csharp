using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class ComplexNumbers : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedClass = "ComplexNumber";
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            
            testMethod.UseVariableForExpected = IsComplexNumber(testMethod.Expected);
            testMethod.Expected = ConvertToType(testMethod.Expected);

            var constructorParamName = testMethod.Input.ContainsKey("z") ? "z" : "z1";
            testMethod.Input["real"] = ConvertToDouble(testMethod.Input[constructorParamName][0]);
            testMethod.Input["imaginary"] = ConvertToDouble(testMethod.Input[constructorParamName][1]);

            testMethod.InputParameters = GetInputParameters(testMethod, constructorParamName);
            testMethod.ConstructorInputParameters = new[] {"real", "imaginary"};

            var keys = testMethod.Input.Keys.ToArray();

            foreach (var key in keys)
                testMethod.Input[key] = ConvertToType(testMethod.Input[key]);

            testMethod.Assert = RenderAssert(testMethod);
        }

        private static string[] GetInputParameters(TestMethod testMethod, string constructorParamName)
            => testMethod.Input.Keys.Where(x => x != constructorParamName).ToArray();

        private string RenderAssert(TestMethod testMethod) 
            => testMethod.UseVariableForExpected
                ? RenderComplexNumberAssert(testMethod)
                : testMethod.Assert;

        private string RenderComplexNumberAssert(TestMethod testMethod)
        {
            var inputParameters = testMethod.Input.ContainsKey("z") ? "" : Render.Object(testMethod.Input["z2"]);
            var actual = $"sut.{testMethod.TestedMethod}({inputParameters})"; 
            
            var assert = new StringBuilder();
            assert.AppendLine(Render.AssertEqualWithin("expected.Real()", $"{actual}.Real()", 7));
            assert.AppendLine(Render.AssertEqualWithin("expected.Imaginary()", $"{actual}.Imaginary()", 7));

            return assert.ToString();
        }

        private object ConvertToType(dynamic rawValue) 
            => IsComplexNumber(rawValue)
                ? RenderComplexNumber(rawValue)
                : rawValue;

        private UnescapedValue RenderComplexNumber(dynamic rawValue) 
            => new($"new ComplexNumber({Render.Object(ConvertToDouble(rawValue[0]))}, {Render.Object(ConvertToDouble(rawValue[1]))})");

        private static bool IsComplexNumber(object rawValue) => rawValue is int[] || rawValue is double[] || rawValue is float[] || rawValue is JArray;

        private static object ConvertToDouble(dynamic value)
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

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Math).Namespace);
        }
    }
}