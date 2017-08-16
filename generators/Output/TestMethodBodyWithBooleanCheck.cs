using System;
using Generators.Input;

namespace Generators.Output
{
    public class TestMethodBodyWithBooleanCheck : TestMethodBody
    {
        public TestMethodBodyWithBooleanCheck(CanonicalDataCase canonicalDataCase, CanonicalData canonicalData) : base(canonicalDataCase, canonicalData)
        {
            AssertTemplateName = "AssertBoolean";
            AssertTemplateParameters = new { BooleanAssertMethod, Data.TestedValue };
        }

        private string BooleanAssertMethod => Convert.ToBoolean(CanonicalDataCase.Expected).ToString();
    }
}