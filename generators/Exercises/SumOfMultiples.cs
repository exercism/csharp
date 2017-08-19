using System;
using System.Linq;
using Generators.Input;

namespace Generators.Exercises
{
    public class SumOfMultiples : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                var hasFactors = canonicalDataCase.Input["factors"].ConvertToEnumerable<long>().Any();

                if (!hasFactors)
                {
                    canonicalDataCase.Input["factors"] = Enumerable.Empty<int>();
                }
            }
        }
    }
}