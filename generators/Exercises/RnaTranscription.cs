using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class RnaTranscription : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Expected = canonicalDataCase.Expected ?? new UnescapedValue("null");
            }
        }
    }
}