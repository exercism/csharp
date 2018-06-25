namespace Exercism.CSharp.Output
{
    public class TestMethodBodyWithEmptyCheck : TestMethodBody
    {
        public TestMethodBodyWithEmptyCheck(TestData data) : base(data)
        {
            Data.UseVariableForExpected = false;
            
            AssertTemplateName = "AssertEmpty";
            AssertTemplateParameters = new { ExpectedParameter, TestedValue };
        }
    }
}