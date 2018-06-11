﻿using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class SimpleCipher : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseFullDescriptionPath = true;

                if (canonicalDataCase.Property == "new")
                {
                    continue;
                }

                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;

                if (canonicalDataCase.Input.ContainsKey("key"))
                {
                    canonicalDataCase.SetConstructorInputParameters("key");
                }

                if (canonicalDataCase.Input.TryGetValue("ciphertext", out var cipherText))
                {
                    if (cipherText == "cipher.key")
                    {
                        canonicalDataCase.Input["ciphertext"] = new UnescapedValue("sut.Key.Substring(0, 10)");
                    }
                    else if (cipherText == "cipher.encode")
                    {
                        var plaintext = ValueFormatter.Format(canonicalDataCase.Input["plaintext"]);
                        canonicalDataCase.Input["ciphertext"] = new UnescapedValue($"sut.Encode({plaintext})");
                        canonicalDataCase.SetInputParameters("ciphertext");
                    }
                }

                if (canonicalDataCase.Expected is string s && s == "cipher.key")
                {
                    canonicalDataCase.Expected = new UnescapedValue("sut.Key.Substring(0, 10)");
                }
            }
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.CanonicalDataCase.Property == "new")
            {
                var key = ValueFormatter.Format(testMethodBody.CanonicalDataCase.Input["key"]);
                return $"Assert.Throws<ArgumentException>(() => new SimpleCipher({key}));";
            }
            else if (testMethodBody.CanonicalDataCase.Property == "key")
            {
                var pattern = ValueFormatter.Format(testMethodBody.CanonicalDataCase.Expected["match"]);
                return $"Assert.Matches({pattern}, sut.Key);";
            }

            return base.RenderTestMethodBodyAssert(testMethodBody);
        }

        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string> { typeof(ArgumentException).Namespace };
    }
}