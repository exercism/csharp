using Generators.Input;

namespace Generators.Exercises
{
    public class Pangram : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Description = canonicalDataCase.Description.Replace("'", string.Empty);
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.Input["input"] = ((string)canonicalDataCase.Input["input"]).Replace("\"", "\\\"");
            }
        }
    }
}