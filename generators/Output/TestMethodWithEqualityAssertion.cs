namespace Exercism.CSharp.Output
{
    public class TestMethodWithEqualityAssertion : TestMethod
    {
        public TestMethodWithEqualityAssertion(TestData data) : base(data)
        {
        }
        
        protected override string RenderAssert() => Assertion.Equal(ExpectedParameter, TestedValue);
    }
}