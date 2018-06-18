using Generators.Input;

namespace Generators.Exercises
{
    public class Matrix : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Properties["string"] = canonicalDataCase.Properties["input"]["string"];
            canonicalDataCase.SetConstructorInputParameters("string");
            canonicalDataCase.Properties["index"] = canonicalDataCase.Properties["input"]["index"];
            canonicalDataCase.SetInputParameters("index");
        }
    }
}
