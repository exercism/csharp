namespace Exercism.CSharp.Output
{
    public class TestMethodWithNullAssertion : TestMethod
    {
        public TestMethodWithNullAssertion(TestData data) : base(data)
        {
        }
        
        protected override string RenderAssert() => Assertion.Null(TestedValue);
    }
}