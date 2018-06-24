using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Forth : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseFullDescriptionPath = true;

            if (data.Expected == null)
            {
                data.ExceptionThrown = typeof(InvalidOperationException);
            }
            else
            {
                data.Expected = string.Join(" ", data.Expected);
            }
        }
    }
}
