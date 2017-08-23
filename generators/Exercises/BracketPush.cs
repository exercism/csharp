using Generators.Input;

namespace Generators.Exercises
{
    public class BracketPush : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Input["input"] = ((string)canonicalDataCase.Input["input"]).Replace("\\", "\\\\");
                canonicalDataCase.UseVariablesForInput = true;
            }
        }
    }
}