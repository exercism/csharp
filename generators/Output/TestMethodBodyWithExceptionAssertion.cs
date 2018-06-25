namespace Exercism.CSharp.Output
{
    public class TestMethodBodyWithExceptionAssertion : TestMethodBody
    {
        public TestMethodBodyWithExceptionAssertion(TestData data) : base(data)
        {
            Data.UseVariableForExpected = false;
            Data.UseVariableForTested = false;

            AssertTemplateName = "AssertThrowsException";
            AssertTemplateParameters = new { ExceptionType, TestedValue };
        }

        private string ExceptionType => Data.ExceptionThrown.Name;
    }
}