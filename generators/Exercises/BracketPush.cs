using Generators.Input;

namespace Generators.Exercises
{
    public class BracketPush : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Input["value"] = canonicalDataCase.Input["value"].Replace("\\", "\\\\");
            canonicalDataCase.UseVariablesForInput = true;
        }
    }
}