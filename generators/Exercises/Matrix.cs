using Generators.Input;

namespace Generators.Exercises
{
    public class Matrix : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Properties["string"] = canonicalDataCase.Properties["input"]["string"];
                canonicalDataCase.SetConstructorInputParameters("string");
                canonicalDataCase.Properties["index"] = canonicalDataCase.Properties["input"]["index"];
                canonicalDataCase.SetInputParameters("index");
            }
        }
    }
}
