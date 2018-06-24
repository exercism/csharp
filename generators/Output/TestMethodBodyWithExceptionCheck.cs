namespace Generators.Output
{
    public class TestMethodBodyWithExceptionCheck : TestMethodBody
    {
        public TestMethodBodyWithExceptionCheck(TestData data) : base(data)
        {
            Data.UseVariableForExpected = false;
            Data.UseVariableForTested = false;

            AssertTemplateName = "AssertThrowsException";
            AssertTemplateParameters = new { ExceptionType, TestedValue };
        }

        private string ExceptionType => Data.ExceptionThrown.Name;
    }
}