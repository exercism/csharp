using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class FlattenArray : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;

            var stringInput = testMethod.Input["array"].ToString();

            // We skip rendering of pure int arrays.
            if (stringInput.Contains("System.Int32"))
                return;

            testMethod.Input["array"] = new UnescapedValue(ConvertToObjectArray(stringInput));
        }

        private static string ConvertToObjectArray(string input)
            => input
                .Replace("System.Int32", "")
                .Replace("]", "}")
                .Replace("[", "new object[] {");
    }
}