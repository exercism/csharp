namespace Generators.Exercises
{
    public class BracketPush : Exercise
    {
        public BracketPush()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Input["input"] = ((string)canonicalDataCase.Input["input"]).Replace("\\", "\\\\");
                canonicalDataCase.UseVariablesForInput = true;
            }
        }
    }
}