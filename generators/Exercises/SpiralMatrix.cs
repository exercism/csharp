using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class SpiralMatrix : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Property = "GetMatrix";
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.Expected = ConvertExpected(canonicalDataCase.Expected);
            }
        }

        private dynamic ConvertExpected(dynamic expected)
        {
            var jArray = (JArray)expected;

            if (jArray.Count == 0)
                return new int[0, 0];

            var rows = jArray.Count;
            var cols = jArray[0].Count();

            var matrix = new int[rows, cols];

            for (var y = 0; y < rows; y++)
            {
                for (var x = 0; x < cols; x++)
                {
                    matrix[y, x] = jArray[y][x].ToObject<int>();
                }
            }

            return matrix;
        }
    }
}
