using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Exercises
{
    public abstract class CustomExercise : Exercise
    {
        public override string Name => GetType().ToExerciseName();
    }
}