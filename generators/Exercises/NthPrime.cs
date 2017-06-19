using System;

namespace Generators.Exercises
{
    public class NthPrime : Exercise
    {
        public NthPrime()
        {
            Options.ExceptionType = typeof(ArgumentOutOfRangeException);
            Options.ThrowExceptionWhenExpectedValueEquals = x => x is bool;
        }
    }
}