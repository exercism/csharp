using System;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class PascalsTriangle : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.UseVariableForExpected = true;
            data.Property = "calculate";
            if (data.Expected is JArray jArray)
                data.Expected = jArray.ToObject<int[][]>();
            else
                data.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}