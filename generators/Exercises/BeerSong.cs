using Generators.Output;

namespace Generators.Exercises
{
    public class BeerSong : Exercise
    {
        public BeerSong()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.Expected = new MultiLineString(canonicalDataCase.Expected.ToString());
        }
    }
}