namespace Exercism.CSharp.Output
{
    public class TestMethodBodyWithEmptyAssertion : TestMethodBody
    {
        public TestMethodBodyWithEmptyAssertion(TestData data) : base(data)
        {
            Data.UseVariableForExpected = false;
            
            AssertTemplateName = "AssertEmpty";
            AssertTemplateParameters = new { ExpectedParameter, TestedValue };
        }
    }
}