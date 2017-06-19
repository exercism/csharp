using Generators.Exercises;
using Generators.Input;

namespace Generators.Output
{
    public class TestMethodData
    {
        public CanonicalData CanonicalData { get; set; }
        public CanonicalDataCase CanonicalDataCase { get; set;}
        public ExerciseConfiguration Configuration { get; set; } = new ExerciseConfiguration();
    }
}