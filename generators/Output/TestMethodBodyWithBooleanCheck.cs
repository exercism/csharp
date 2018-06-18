using System;
using Generators.Input;

namespace Generators.Output
{
    public class TestMethodBodyWithBooleanCheck : TestMethodBody
    {
        public TestMethodBodyWithBooleanCheck(CanonicalDataCase canonicalDataCase) : base(canonicalDataCase)
        {
            AssertTemplateName = "AssertBoolean";
            AssertTemplateParameters = new { BooleanAssertMethod, Data.TestedValue };
        }

        private string BooleanAssertMethod => Convert.ToBoolean(CanonicalDataCase.Expected).ToString();
    }
}