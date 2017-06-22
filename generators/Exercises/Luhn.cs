namespace Generators.Exercises
{
    public class Luhn : Exercise
    {
        public Luhn()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.Property = "IsValid";
        }
    }
}
