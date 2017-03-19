using System;

namespace Generators
{
    public class BooleanTestMethod : TestMethodBase
    {
        public BooleanTestMethod(TestMethodData testMethodData) : base(testMethodData)
        {
        }

        protected override string GetBody(TestMethodData testMethodData)
        {
            var isTrue = Convert.ToBoolean(testMethodData.CanonicalDataCase.Expected);
            var testedClassName = GetTestedClassName(testMethodData);
            var testedMethod = GetTestedMethod(testMethodData);
            var input = testMethodData.CanonicalDataCase.Input;

            return $"Assert.{isTrue}({testedClassName}.{testedMethod}({input}));";
        }

        protected override string GetTestedMethod(TestMethodData testMethodData)
        {
            var testedMethod = base.GetTestedMethod(testMethodData);
            return testedMethod.StartsWith("Is") ? testedMethod : "Is" + testedMethod;
        }
    }
}