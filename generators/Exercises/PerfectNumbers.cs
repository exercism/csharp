using System;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class PerfectNumbers : EqualityExercise
    {
        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase);
            testMethodData.Options.ExceptionType = typeof(ArgumentOutOfRangeException);
            testMethodData.Options.ExpectedFormat = ExpectedFormat.Unformatted;

            if (testMethodData.CanonicalDataCase.Expected is string classificationType)
                testMethodData.CanonicalDataCase.Expected = GetClassification(classificationType);

            return testMethodData;
        }

        private static string GetClassification(string classificationType) 
            => $"Classification.{classificationType.Transform(To.TitleCase)}";
    }
}