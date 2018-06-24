using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class CollatzConjecture : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.ExceptionThrown = data.Input["number"] <= 0 ? typeof(ArgumentException) : null;
        }
    }
}