namespace Exercism.CSharp.Output
{
    public class TestMethodBodyWithNullAssertion : TestMethodBody
    {
        public TestMethodBodyWithNullAssertion(TestData data) : base(data)
        {
            AssertTemplateName = "AssertNull";
            AssertTemplateParameters = new { TestedValue };
        }
    }
}