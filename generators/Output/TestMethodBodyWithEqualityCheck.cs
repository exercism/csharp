namespace Exercism.CSharp.Output
{
    public class TestMethodBodyWithEqualityCheck : TestMethodBody
    {
        public TestMethodBodyWithEqualityCheck(TestData data) : base(data)
        {
            AssertTemplateName = "AssertEqual";
            AssertTemplateParameters = new { ExpectedParameter, TestedValue };
        }
    }
}