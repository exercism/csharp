using System.Linq;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class SpiralMatrix : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.Property = "GetMatrix";
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
