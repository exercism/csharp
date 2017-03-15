using System;
using Humanizer;

namespace Generators
{
    public class BooleanTestMethod : TestMethod
    {
        public BooleanTestMethod(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            Index = index;
            MethodName = GetMethodName(canonicalDataCase);
            Body = GetBody(canonicalData, canonicalDataCase);
        }

        private static string GetMethodName(CanonicalDataCase canonicalDataCase)
            => canonicalDataCase.Description.Replace(":", " is").Transform(To.TestMethodName);

        private static string GetBody(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
        {
            var isTrue = Convert.ToBoolean(canonicalDataCase.Expected);
            var testedClassName = GetTestedClassName(canonicalData);
            var testedMethod = GetTestedMethod(canonicalDataCase);

            return $"Assert.{isTrue}({testedClassName}.{testedMethod}({canonicalDataCase.Input}));";
        }

        private static string GetTestedClassName(CanonicalData canonicalData)
            => canonicalData.Exercise.Transform(To.TestedClassName);

        private static string GetTestedMethod(CanonicalDataCase canonicalDataCase)
        {
            var testedMethod = canonicalDataCase.Property.Transform(To.TestedMethodName);
            return testedMethod.StartsWith("Is") ? testedMethod : "Is" + testedMethod;
        }
    }
}