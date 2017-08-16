using Generators.Input;

namespace Generators.Output
{
    public class TestMethodBodyWithExceptionCheck : TestMethodBody
    {
        public TestMethodBodyWithExceptionCheck(CanonicalDataCase canonicalDataCase, CanonicalData canonicalData) : base(canonicalDataCase, canonicalData)
        {
            AssertTemplateName = "AssertThrowsException";
            AssertTemplateParameters = new { ExceptionType, Data.TestedValue };
        }

        public override bool UseVariableForExpected => false;
        public override bool UseVariableForTested => false;

        private string ExceptionType => CanonicalDataCase.ExceptionThrown.Name;
    }
}