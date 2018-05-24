using Generators.Input;

namespace Generators.Exercises
{
    public class SumOfMultiples : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Input["factors"] = ConvertHelper.ToArray<int>(canonicalDataCase.Input["factors"]);
            }
        }
    }
}