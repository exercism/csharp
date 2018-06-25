namespace Exercism.CSharp.Output
{
    public class TestMethodBodyWithEqualityAssertion : TestMethodBody
    {
        public TestMethodBodyWithEqualityAssertion(TestData data) : base(data)
        {
            AssertTemplateName = "AssertEqual";
            AssertTemplateParameters = new { ExpectedParameter, TestedValue };
        }
    }
}