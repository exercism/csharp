namespace Exercism.CSharp.Output
{
    public class TestMethodWithExceptionAssertion : TestMethod
    {
        public TestMethodWithExceptionAssertion(TestData data) : base(data)
        {
            Data.UseVariableForExpected = false;
            Data.UseVariableForTested = false;
        }
        
        protected override string RenderAssert() => Assertion.Exception(TestedValue, Data.ExceptionThrown);
    }
}