namespace Generators.Exercises
{
    public class BeerSong : Exercise
    {
        public BeerSong()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.UseExpectedParameter = true;
        }
    }
}