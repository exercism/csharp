using System;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
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