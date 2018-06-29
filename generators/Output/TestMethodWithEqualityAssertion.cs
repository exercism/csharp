using System.Collections.Generic;

namespace Exercism.CSharp.Output
{
    public class TestMethodWithEqualityAssertion : TestMethod
    {
        public TestMethodWithEqualityAssertion(TestData data) : base(data)
        {
        }
        
        protected override IEnumerable<string> RenderAssert() => Assertion.Equal(TestedValue, ExpectedParameter);
    }
}