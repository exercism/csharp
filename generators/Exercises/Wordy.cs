using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class Wordy : Exercise
    {
        public Wordy()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is bool ? typeof(ArgumentException) : null;
        }

        protected override TestClass CreateTestClass()
        {
            var testClass = base.CreateTestClass();
            testClass.UsingNamespaces.Add(typeof(ArgumentException).Namespace);

            return testClass;
        }
    }
}