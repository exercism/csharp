namespace Generators.Exercises
{
    public class Wordy : EqualityExercise
    {
        public Wordy()
        {
            Options.ThrowExceptionWhenExpectedValueEquals = x => x is bool;
        }
    }
}