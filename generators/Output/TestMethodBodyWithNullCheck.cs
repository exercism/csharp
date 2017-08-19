using Generators.Input;

namespace Generators.Output
{
    public class TestMethodBodyWithNullCheck : TestMethodBody
    {
        public TestMethodBodyWithNullCheck(CanonicalDataCase canonicalDataCase, CanonicalData canonicalData) : base(canonicalDataCase, canonicalData)
        {
            AssertTemplateName = "AssertNull";
            AssertTemplateParameters = new { Data.TestedValue };
        }
    }
}