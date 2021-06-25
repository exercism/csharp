using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Humanizer;

namespace Exercism.CSharp.Exercises.Generators
{
    public class DiffieHellman : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            switch (testMethod.Property)
            {
                case "privateKeyIsInRange":
                    UpdateTestMethodForPrivateKeyIsInRangeProperty(testMethod);
                    break;
                case "privateKeyIsRandom":
                    UpdateTestMethodForPrivateKeyIsRandomProperty(testMethod);
                    break;
                case "keyExchange":
                    UpdateTestMethodForKeyExchangeProperty(testMethod);
                    break;
                default:
                    UpdateTestMethodForNormalProperty(testMethod);
                    break;
            }
        }

        private void UpdateTestMethodForPrivateKeyIsInRangeProperty(TestMethod testMethod)
        {
            testMethod.TestedMethod = "PrivateKey";
            testMethod.Expected["greaterThan"] = new BigInteger(testMethod.Expected["greaterThan"]);
            
            testMethod.Arrange = RenderArrangeForPrivateKeyIsInRangeProperty(testMethod);
            testMethod.Assert = RenderAssertForPrivateKeyIsInRangeProperty(testMethod);
        }

        private string RenderArrangeForPrivateKeyIsInRangeProperty(TestMethod testMethod) 
            => RenderRandomPrivateKeysArrange(testMethod);

        private string RenderAssertForPrivateKeyIsInRangeProperty(TestMethod testMethod)
        {
            var arrange = new StringBuilder();
            
            arrange.AppendLine("foreach (var privateKey in privateKeys)");
            arrange.AppendLine("{");
            arrange.AppendLine(((string)Render.AssertInRange("privateKey", Render.Object(testMethod.Expected["greaterThan"]), "p")).Indent());
            arrange.AppendLine("}");
            
            return arrange.ToString();
        }
        
        private void UpdateTestMethodForPrivateKeyIsRandomProperty(TestMethod testMethod)
        {
            testMethod.TestedMethod = "PrivateKey";
            testMethod.Arrange = RenderArrangeForPrivateKeyIsRandomProperty(testMethod);
            testMethod.Assert = RenderAssertForPrivateKeyIsRandomProperty();
        }

        private string RenderArrangeForPrivateKeyIsRandomProperty(TestMethod testMethod) 
            => RenderRandomPrivateKeysArrange(testMethod);

        private string RenderAssertForPrivateKeyIsRandomProperty() 
            => Render.AssertEqual("privateKeys.Distinct().Count()", "privateKeys.Length");

        private string RenderRandomPrivateKeysArrange(TestMethod testMethod)
        {
            var arrange = new StringBuilder();

            arrange.AppendLine(Render.Variable("p", Render.BigInteger(new BigInteger(7919))));
            arrange.AppendLine(Render.Variable("privateKeys", $"Enumerable.Range(0, 10).Select(_ => {testMethod.TestedClass}.{testMethod.TestedMethod}(p)).ToArray()"));

            return arrange.ToString();
        }
        
        private void UpdateTestMethodForKeyExchangeProperty(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            
            var keys = testMethod.Input.Keys.ToArray();

            foreach (var key in keys)
                testMethod.Input[key] = ConvertKeyExchangeInput(testMethod.Input[key], testMethod);
            
            testMethod.Assert = RenderAssertForKeyExchangeProperty();
        }
        
        private static dynamic ConvertKeyExchangeInput(dynamic input, TestMethod testMethod)
        {
            switch (input)
            {
                case int i:
                    return new BigInteger(i);
                case string str:
                    return new UnescapedValue($"{testMethod.TestedClass}.{char.ToUpper(str[0]) + str.Substring(1)}");
                default:
                    return input;
            }
        }

        private string RenderAssertForKeyExchangeProperty() => Render.AssertEqual("secretA", "secretB");

        private static void UpdateTestMethodForNormalProperty(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.Expected = new BigInteger(testMethod.Expected);

            var keys = testMethod.Input.Keys.ToArray();

            foreach (var key in keys)
                testMethod.Input[key] = new BigInteger(testMethod.Input[key]);
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(BigInteger).Namespace);
            namespaces.Add(typeof(Enumerable).Namespace);
        }
    }
}