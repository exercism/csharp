using System;
using Generators.Data;
using Generators.Methods;
using Humanizer;

namespace Generators.Exercises
{
    public class PerfectNumbersExercise : EqualityExercise
    {
        public PerfectNumbersExercise() : base("perfect-numbers")
        {
        }

        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase, index);
            testMethodData.Options.ExceptionType = typeof(ArgumentOutOfRangeException);
            testMethodData.Options.FormatExpected = false;

            if (testMethodData.CanonicalDataCase.Expected is string classificationType)
                testMethodData.CanonicalDataCase.Expected = GetClassification(classificationType);

            return testMethodData;
        }

        private static string GetClassification(string classificationType) 
            => $"Classification.{classificationType.Transform(Humanizer.To.TitleCase)}";
    }
}