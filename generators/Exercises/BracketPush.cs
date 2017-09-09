using Generators.Input;

namespace Generators.Exercises
{
    public class BracketPush : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Properties["input"] = canonicalDataCase.Properties["input"].Replace("\\", "\\\\");
                canonicalDataCase.UseVariablesForInput = true;
            }
        }
    }
}