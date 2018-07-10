using System;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Sieve : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;

            if (testMethod.Input["limit"] < 2)
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
            else
                testMethod.Expected = RenderAsSingleLineArray(testMethod.Expected);
        }
        
        private UnescapedValue RenderAsSingleLineArray(dynamic value) 
            => new UnescapedValue(Render.Array(value as int[] ?? Array.Empty<int>()));
    }
}