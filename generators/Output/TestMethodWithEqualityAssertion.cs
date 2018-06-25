namespace Exercism.CSharp.Output
{
    public class TestMethodWithEqualityAssertion : TestMethod
    {
        public TestMethodWithEqualityAssertion(TestData data) : base(data)
        {
            AssertTemplateName = "AssertEqual";
            AssertTemplateParameters = new { ExpectedParameter, TestedValue };
        }
    }
}