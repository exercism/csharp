using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Say : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "InEnglish";

            if (data.Expected is int)
                data.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}