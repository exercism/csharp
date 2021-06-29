using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class PerfectNumbers : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Expected is string)
                testMethod.Expected = Render.Enum("Classification", testMethod.Expected);
            else
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}