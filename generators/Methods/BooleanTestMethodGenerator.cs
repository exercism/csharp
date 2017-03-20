using System;
using Generators.Helpers;

namespace Generators.Methods
{
    public class BooleanTestMethodGenerator : TestMethodGenerator
    {
        protected override string Body => $"{Assertion}({TestedClassName}.{TestedMethod}({Input}));";

        private string Assertion
            => $"Assert.{Convert.ToBoolean(TestMethodData.CanonicalDataCase.Expected)}";

        protected override string TestedMethod
            => base.TestedMethod.EnsureStartsWith("Is");
    }
}