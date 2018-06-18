using Generators.Input;

namespace Generators.Output
{
    public class TestMethodBodyWithNullCheck : TestMethodBody
    {
        public TestMethodBodyWithNullCheck(CanonicalDataCase canonicalDataCase) : base(canonicalDataCase)
        {
            AssertTemplateName = "AssertNull";
            AssertTemplateParameters = new { Data.TestedValue };
        }
    }
}