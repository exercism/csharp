using Generators.Input;

namespace Generators.Exercises
{
    public class LargestSeriesProduct : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Property = "GetLargestProduct";
                
                var caseInputLessThanZero = (long)canonicalDataCase.Expected == -1;
                canonicalDataCase.ExceptionThrown = caseInputLessThanZero ? typeof(System.ArgumentException) : null;
            }
        }
    }
}