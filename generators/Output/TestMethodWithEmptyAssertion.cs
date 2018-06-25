namespace Exercism.CSharp.Output
{
    public class TestMethodWithEmptyAssertion : TestMethod
    {
        public TestMethodWithEmptyAssertion(TestData data): base(data)
        {
            Data.UseVariableForExpected = false;
            
            AssertTemplateName = "AssertEmpty";
            AssertTemplateParameters = new { ExpectedParameter, TestedValue };
        }
    }
}