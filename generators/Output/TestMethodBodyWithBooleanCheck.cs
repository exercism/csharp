using System;
using Generators.Input;

namespace Generators.Output
{
    public class TestMethodBodyWithBooleanCheck : TestMethodBody
    {
        public TestMethodBodyWithBooleanCheck(TestMethodBodyData data) : base(data)
        {
            AssertTemplateName = "AssertBoolean";
            AssertTemplateParameters = new { BooleanAssertMethod, Data.TestedValue };
        }

        private string BooleanAssertMethod => Convert.ToBoolean(Data.CanonicalDataCase.Expected).ToString();
    }
}