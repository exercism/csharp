using System;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class PascalsTriangle : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
            data.TestedMethod = "Calculate";
            if (data.Expected is JArray jArray)
                data.Expected = jArray.ToObject<int[][]>();
            else
                data.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}