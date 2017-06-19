using System;

namespace Generators.Exercises
{
    public class NthPrime : Exercise
    {
        public NthPrime()
        {
            Configuration.ExceptionType = typeof(ArgumentOutOfRangeException);
            Configuration.ThrowExceptionWhenExpectedValueEquals = x => x is bool;
        }
    }
}