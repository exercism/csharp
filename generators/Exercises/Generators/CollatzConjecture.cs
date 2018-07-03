using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class CollatzConjecture : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Input["number"] <= 0)
                data.ExceptionThrown = typeof(ArgumentException);
        }
    }
}