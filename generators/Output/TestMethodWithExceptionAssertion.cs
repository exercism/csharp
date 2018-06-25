namespace Exercism.CSharp.Output
{
    public class TestMethodWithExceptionAssertion : TestMethod
    {
        public TestMethodWithExceptionAssertion(TestData data) : base(data)
        {
            Data.UseVariableForExpected = false;
            Data.UseVariableForTested = false;

            AssertTemplateName = "AssertException";
            AssertTemplateParameters = new { ExceptionType, TestedValue };
        }

        private string ExceptionType => Data.ExceptionThrown.Name;
    }
}