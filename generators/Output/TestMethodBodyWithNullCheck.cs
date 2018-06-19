namespace Generators.Output
{
    public class TestMethodBodyWithNullCheck : TestMethodBody
    {
        public TestMethodBodyWithNullCheck(TestMethodBodyData data) : base(data)
        {
            AssertTemplateName = "AssertNull";
            AssertTemplateParameters = new { Data.TestedValue };
        }
    }
}