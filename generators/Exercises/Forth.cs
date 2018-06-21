using System;
using Generators.Output;

namespace Generators.Exercises
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
