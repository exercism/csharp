using System;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class PascalsTriangle : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;
            testMethod.TestedMethod = "Calculate";

            if (testMethod.Expected is JArray jArray)
                testMethod.Expected = jArray.ToObject<int[][]>();
            else
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}