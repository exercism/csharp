using System.Collections.Generic;

namespace Exercism.CSharp.Output
{
    public class TestMethodWithNullAssertion : TestMethod
    {
        public TestMethodWithNullAssertion(TestData data) : base(data)
        {
        }
        
        protected override IEnumerable<string> RenderAssert() => Assertion.Null(TestedValue);
    }
}