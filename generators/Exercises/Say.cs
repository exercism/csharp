using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class Say : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Property = "InEnglish";
            data.ExceptionThrown = data.Expected is int ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}