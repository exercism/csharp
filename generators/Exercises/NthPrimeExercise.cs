using System;
using Generators.Methods;

namespace Generators.Exercises
{
    public class NthPrimeExercise : EqualityExercise
    {
        public NthPrimeExercise() : base("nth-prime")
        {
        }

        protected override TestMethod CreateTestMethod(TestMethodData testMethodData)
        {
            if (testMethodData.CanonicalDataCase.Expected is bool b && !b)
            {
                testMethodData.Options.ExceptionType = typeof(ArgumentOutOfRangeException);
                return CreateExceptionTestMethod(testMethodData);
            }

            return CreateEqualityTestMethod(testMethodData);
        }   
    }
}