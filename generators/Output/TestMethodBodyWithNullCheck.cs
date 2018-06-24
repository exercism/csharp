namespace Exercism.CSharp.Output
{
    public class TestMethodBodyWithNullCheck : TestMethodBody
    {
        public TestMethodBodyWithNullCheck(TestData data) : base(data)
        {
            AssertTemplateName = "AssertNull";
            AssertTemplateParameters = new { TestedValue };
        }
    }
}