using System;
using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
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

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            switch (testMethodBody.Data.Property)
            {
                case "new":
                    var key = ValueFormatter.Format(testMethodBody.Data.Input["key"]);
                    return new[] { $"Assert.Throws<ArgumentException>(() => new SimpleCipher({key}));" };
                case "key":
                    var pattern = ValueFormatter.Format(testMethodBody.Data.Expected["match"]);
                    return new[] { $"Assert.Matches({pattern}, sut.Key);" };
                default:
                    return base.RenderTestMethodBodyAssert(testMethodBody);
            }
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(ArgumentException).Namespace };
    }
}