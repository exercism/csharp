using Generators.Input;

namespace Generators.Exercises
{
    public class BookStore : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.SetInputParameters("basket");
                canonicalDataCase.UseVariablesForInput = true;
            }
        }
    }
}