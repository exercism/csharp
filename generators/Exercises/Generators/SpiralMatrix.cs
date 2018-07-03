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

        private static int[,] ConvertExpected(JArray jArray) => jArray.ToObject<int[,]>();
    }
}
