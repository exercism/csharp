using Generators.Exercises;
using Generators.Input;

namespace Generators.Output
{
    public class TestMethodData
    {
        public CanonicalData CanonicalData { get; set; }
        public CanonicalDataCase CanonicalDataCase { get; set;}
        public ExerciseConfiguration Options { get; set; } = new ExerciseConfiguration();
    }
}