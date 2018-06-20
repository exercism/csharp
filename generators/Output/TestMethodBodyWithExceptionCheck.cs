namespace Generators.Output
{
    public class TestMethodBodyWithExceptionCheck : TestMethodBody
    {
        public TestMethodBodyWithExceptionCheck(TestMethodBodyData data) : base(data)
        {
            Data.UseVariableForExpected = false;
            Data.UseVariableForTested = false;
            InitializeTemplateParameters();
            
            AssertTemplateName = "AssertThrowsException";
            AssertTemplateParameters = new { ExceptionType, Data.TestedValue };
        }

        private string ExceptionType => Data.ExceptionThrown.Name;
    }
}