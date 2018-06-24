using System.Linq;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class SpiralMatrix : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "GetMatrix";
            data.UseVariableForExpected = true;
            data.Expected = ConvertExpected(data.Expected);
        }

        private static dynamic ConvertExpected(dynamic expected)
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
