﻿using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class SimpleCipher : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseFullDescriptionPath = true;

            if (data.Property == "new")
            {
                return;
            }

            data.TestedMethodType = TestedMethodType.Instance;

            if (data.Input.ContainsKey("key"))
            {
                data.SetConstructorInputParameters("key");
            }

            if (data.Input.TryGetValue("ciphertext", out var cipherText))
            {
                if (cipherText.StartsWith("cipher.key.substring"))
                {
                    data.Input["ciphertext"] = new UnescapedValue($"sut.Key.Substring(0, {data.Expected.Length})");
                }
                else if (cipherText == "cipher.encode")
                {
                    var plaintext = Render.Object(data.Input["plaintext"]);
                    data.Input["ciphertext"] = new UnescapedValue($"sut.Encode({plaintext})");
                    data.SetInputParameters("ciphertext");
                }
            }

            if (data.Expected is string s && s.StartsWith("cipher.key.substring"))
            {
                data.Expected = new UnescapedValue($"sut.Key.Substring(0, {data.Input["plaintext"].Length})");
            }
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private string RenderAssert(TestMethod method)
        {
            switch (method.Data.Property)
            {
                case "new":
                    var key = Render.Object(method.Data.Input["key"]);
                    return Render.AssertThrows<ArgumentException>($"new SimpleCipher({key})");
                case "key":
                    var pattern = Render.Object(method.Data.Expected["match"]);
                    return Render.AssertMatches(pattern, "sut.Key");
                default:
                    return method.Assert;
            }
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(ArgumentException).Namespace);
        }
    }
}