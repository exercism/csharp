using Generators.Input;
using Humanizer;

namespace Generators.Exercises
{
    public abstract class Exercise
    {
        protected Exercise()
        {
            Name = GetType().Name.Kebaberize();
            CanonicalData = CanonicalDataParser.Parse(Name);
            Configuration = new ExerciseConfiguration();
        }

        public string Name { get; }
        public CanonicalData CanonicalData { get; }
        public ExerciseConfiguration Configuration { get; }
    }
}