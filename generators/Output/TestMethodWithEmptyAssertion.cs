using System.Collections.Generic;

namespace Exercism.CSharp.Output
{
    public class TestMethodWithEmptyAssertion : TestMethod
    {
        public TestMethodWithEmptyAssertion(TestData data): base(data)
        {
            Data.UseVariableForExpected = false;
        }

        protected override IEnumerable<string> RenderAssert() => Assertion.Empty(TestedValue, ExpectedParameter);
    }
}