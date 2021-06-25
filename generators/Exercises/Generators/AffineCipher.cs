using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class AffineCipher : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Input["a"] = testMethod.Input["key"]["a"];
            testMethod.Input["b"] = testMethod.Input["key"]["b"];
            testMethod.InputParameters = new[] { "phrase", "a", "b" };

            if (!(testMethod.Expected is string))
            {
                testMethod.ExceptionThrown = typeof(ArgumentException);
            }
        }
    }
}
