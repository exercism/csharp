using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class SimpleCipher : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestMethodName = testMethod.TestMethodNameWithPath;
            
            if (testMethod.Input.ContainsKey("key"))
            {
                testMethod.SetConstructorInputParameters("key");
            }

            if (testMethod.Property == "new")
            {
                testMethod.TestedMethodType = TestedMethodType.Constructor;
                testMethod.ExceptionThrown = typeof(ArgumentException);
                return;
            }

            if (testMethod.Property == "key")
            {
                testMethod.Expected = new Regex(testMethod.Expected["match"]);
                testMethod.TestedMethodType = TestedMethodType.Property;
                return;
            }

            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;

            if (testMethod.Input.TryGetValue("ciphertext", out var cipherText))
            {
                if (cipherText.StartsWith("cipher.key.substring"))
                {
                    testMethod.Input["ciphertext"] = new UnescapedValue($"sut.Key.Substring(0, {testMethod.Expected.Length})");
                }
                else if (cipherText == "cipher.encode")
                {
                    var plaintext = Render.Object(testMethod.Input["plaintext"]);
                    testMethod.Input["ciphertext"] = new UnescapedValue($"sut.Encode({plaintext})");
                    testMethod.SetInputParameters("ciphertext");
                }
            }

            if (testMethod.Expected is string s && s.StartsWith("cipher.key.substring"))
            {
                testMethod.Expected = new UnescapedValue($"sut.Key.Substring(0, {testMethod.Input["plaintext"].Length})");
            }
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(ArgumentException).Namespace);
        }
    }
}