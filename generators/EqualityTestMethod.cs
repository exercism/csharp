namespace Generators
{
    public class EqualityTestMethod : TestMethodBase
    {
        public EqualityTestMethod(TestMethodData testMethodData) : base(testMethodData)
        {
        }

        protected override string GetBody(TestMethodData testMethodData)
        {
            var input = GetInput(testMethodData);
            var expected = GetExpected(testMethodData);
            var testedClassName = GetTestedClassName(testMethodData);
            var testedMethod = GetTestedMethod(testMethodData);

            return $"Assert.Equals({expected}, {testedClassName}.{testedMethod}({input}));";
        }

        protected virtual object GetInput(TestMethodData testMethodData)
        {
            if (testMethodData.InputProperty != null)
                return FormatValue(testMethodData.CanonicalDataCase.Data[testMethodData.InputProperty]);

            return FormatValue(testMethodData.CanonicalDataCase.Input);
        }

        protected virtual object GetExpected(TestMethodData testMethodData)
            => FormatValue(testMethodData.CanonicalDataCase.Expected);

        private static object FormatValue(object val)
        {
            switch (val)
            {
                case string s:
                    return $"\"{s}\"";
                default:
                    return val;
            }
        }
    }
}