using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Say : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "InEnglish";
            data.ExceptionThrown = data.Expected is int ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}