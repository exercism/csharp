using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class CollatzConjecture : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Input["number"] <= 0)
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}
