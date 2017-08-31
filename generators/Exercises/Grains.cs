using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Grains : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                if (ShouldThrowException(canonicalDataCase.Expected))
                {
                    canonicalDataCase.ExceptionThrown = typeof(ArgumentOutOfRangeException);
                }
                else
                {
                    canonicalDataCase.Expected = ulong.Parse(canonicalDataCase.Expected.ToString());
                }
            }
        }

        private static bool ShouldThrowException(object value)
        {
            return int.TryParse(value.ToString(), out int result)
                && result == -1;
        }
    }
}