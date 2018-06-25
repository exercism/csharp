using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;

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
                switch (cipherText)
                {
                    case "cipher.key":
                        data.Input["ciphertext"] = new UnescapedValue("sut.Key.Substring(0, 10)");
                        break;
                    case "cipher.encode":
                        var plaintext = ValueFormatter.Format(data.Input["plaintext"]);
                        data.Input["ciphertext"] = new UnescapedValue($"sut.Encode({plaintext})");
                        data.SetInputParameters("ciphertext");
                        break;
                }
            }

            if (data.Expected is string s && s == "cipher.key")
            {
                data.Expected = new UnescapedValue("sut.Key.Substring(0, 10)");
            }
        }

        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody body)
        {
            switch (body.Data.Property)
            {
                case "new":
                    var key = ValueFormatter.Format(body.Data.Input["key"]);
                    return new[] { $"Assert.Throws<ArgumentException>(() => new SimpleCipher({key}));" };
                case "key":
                    var pattern = ValueFormatter.Format(body.Data.Expected["match"]);
                    return new[] { $"Assert.Matches({pattern}, sut.Key);" };
                default:
                    return body.Assert;
            }
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(ArgumentException).Namespace);
        }
    }
}