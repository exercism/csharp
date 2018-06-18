using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class FlattenArray : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.UseVariableForExpected = true;

            var stringInput = canonicalDataCase.Input["array"].ToString();

            // We skip reformatting of pure int arrays.
            if (stringInput.Contains("System.Int32"))
                return;

            canonicalDataCase.Input["array"] = new UnescapedValue(ToProperObjArray(stringInput));
        }

        private string ToProperObjArray(string input)
            => input
                .Replace("System.Int32", "")
                .Replace("]", "}")
                .Replace("[", "new object[] {");
    }
}