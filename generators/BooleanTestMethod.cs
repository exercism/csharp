using System;

namespace Generators
{
    public class BooleanTestMethod : TestMethodBase
    {
        public BooleanTestMethod(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
            : base(canonicalData, canonicalDataCase, index)
        {
        }

        protected override string GetBody(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
        {
            var isTrue = Convert.ToBoolean(canonicalDataCase.Expected);
            var testedClassName = GetTestedClassName(canonicalData);
            var testedMethod = GetTestedMethod(canonicalDataCase);

            return $"Assert.{isTrue}({testedClassName}.{testedMethod}({canonicalDataCase.Input}));";
        }

        protected override string GetTestedMethod(CanonicalDataCase canonicalDataCase)
        {
            var testedMethod = base.GetTestedMethod(canonicalDataCase);
            return testedMethod.StartsWith("Is") ? testedMethod : "Is" + testedMethod;
        }
    }
}