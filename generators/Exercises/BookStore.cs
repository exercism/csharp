using Generators.Input;

namespace Generators.Exercises
{
    public class BookStore : Exercise
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