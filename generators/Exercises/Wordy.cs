namespace Generators.Exercises
{
    public class Wordy : Exercise
    {
        public Wordy()
        {
            Configuration.ThrowExceptionWhenExpectedValueEquals = x => x is bool;
        }
    }
}