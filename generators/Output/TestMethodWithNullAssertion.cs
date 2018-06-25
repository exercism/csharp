namespace Exercism.CSharp.Output
{
    public class TestMethodWithNullAssertion : TestMethod
    {
        public TestMethodWithNullAssertion(TestData data) : base(data)
        {
            AssertTemplateName = "AssertNull";
            AssertTemplateParameters = new { TestedValue };
        }
    }
}