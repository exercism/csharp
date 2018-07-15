using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class PerfectNumbers : GeneratorExercise
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