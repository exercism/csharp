using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class NthPrime : Exercise
    {
        public NthPrime()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is bool ? typeof(ArgumentOutOfRangeException) : null;
        }

        protected override TestClass CreateTestClass()
        {
            var testClass = base.CreateTestClass();
            testClass.UsingNamespaces.Add(typeof(ArgumentOutOfRangeException).Namespace);

            return testClass;
        }
    }
}