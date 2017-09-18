using Generators.Input;

namespace Generators.Exercises
{
    public class BinarySearch : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForConstructorParameters = true;
                canonicalDataCase.SetConstructorInputParameters("array");
            }
        }
    }
}