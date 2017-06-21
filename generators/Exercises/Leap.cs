namespace Generators.Exercises
{
    public class Leap : Exercise
    {
        public Leap()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.Property = "IsLeapYear";
        }
    }
}