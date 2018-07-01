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
            return jArray.Count == 0 ? new int[0, 0] : jArray.ToObject<int[,]>();
        }
    }
}
