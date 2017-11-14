using Generators.Output;

namespace Generators
{
    public abstract class CustomExercise : Exercise
    {
        public override string Name => GetType().ToExerciseName();
    }
}