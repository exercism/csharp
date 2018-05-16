using Generators.Input;

namespace Generators.Exercises
{
    public class BracketPush : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Input["value"] = canonicalDataCase.Input["value"].Replace("\\", "\\\\");
                canonicalDataCase.UseVariablesForInput = true;
            }
        }
    }
}