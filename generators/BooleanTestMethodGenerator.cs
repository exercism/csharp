using System;

namespace Generators
{
    public class BooleanTestMethodGenerator : TestMethodGenerator
    {
        protected override string GetBody()
            => $"{Assertion}({TestedClassName}.{TestedMethod}({Input}));";

        private string Assertion
            => $"Assert.{Convert.ToBoolean(TestMethodData.CanonicalDataCase.Expected)}";

        protected override string TestedMethod
            => base.TestedMethod.EnsureStartsWith("Is");
    }
}