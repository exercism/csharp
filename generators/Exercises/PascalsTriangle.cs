using System;
using Generators.Input;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class PascalsTriangle : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.Property = "calculate";
                if (canonicalDataCase.Expected is JArray jArray)
                    canonicalDataCase.Expected = jArray.ToObject<int[][]>();
                else
                    canonicalDataCase.ExceptionThrown = typeof(ArgumentOutOfRangeException);
            }
        }
    }
}