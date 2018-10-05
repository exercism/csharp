using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class AffineCipher : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Assert = RenderAssert(testMethod);
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add("System");
        }

        private string RenderAssert(TestMethod testMethod)
        {
            var assert = new StringBuilder();

            var a = Convert.ToInt32(testMethod.Input["key"]["a"]);
            var b = Convert.ToInt32(testMethod.Input["key"]["b"]);

            assert.AppendLine("var ac = new AffineCipher();");

            if (testMethod.Expected is string s)
            {
                assert.AppendLine(Render.AssertEqual($"\"{s}\"", $"ac.{testMethod.TestedMethod}(\"{testMethod.Input["phrase"]}\",{a},{b})"));
            }
            else
            {
                assert.Append("Exception ex = ");
                assert.AppendLine(Render.AssertThrows(typeof(ArgumentException), $"ac.{testMethod.TestedMethod}(\"{testMethod.Input["phrase"]}\",{a},{b})"));
                assert.AppendLine(Render.AssertEqual($"\"{testMethod.Expected["error"]}\"", "ex.Message"));
            }

            return assert.ToString();
        }
    }
}
