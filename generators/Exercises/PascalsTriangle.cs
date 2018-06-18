using System;
using Generators.Input;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class PascalsTriangle : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
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