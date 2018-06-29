namespace Exercism.CSharp.Output
{
    public class TestMethodWithEmptyAssertion : TestMethod
    {
        public TestMethodWithEmptyAssertion(TestData data): base(data)
        {
            Data.UseVariableForExpected = false;
        }

        protected override string RenderAssert() => Assertion.Empty(ExpectedParameter, TestedValue);
    }
}