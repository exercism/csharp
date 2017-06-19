namespace Generators.Exercises
{
    public class Wordy : Exercise
    {
        public Wordy()
        {
            Options.ThrowExceptionWhenExpectedValueEquals = x => x is bool;
        }
    }
}