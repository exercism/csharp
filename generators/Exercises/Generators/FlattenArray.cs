using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class FlattenArray : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;

            var stringInput = data.Input["array"].ToString();

            // We skip reformatting of pure int arrays.
            if (stringInput.Contains("System.Int32"))
                return;

            data.Input["array"] = new UnescapedValue(ToProperObjArray(stringInput));
        }

        private static string ToProperObjArray(string input)
            => input
                .Replace("System.Int32", "")
                .Replace("]", "}")
                .Replace("[", "new object[] {");
    }
}