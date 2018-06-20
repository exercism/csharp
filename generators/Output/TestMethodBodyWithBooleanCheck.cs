using System;

namespace Generators.Output
{
    public class TestMethodBodyWithBooleanCheck : TestMethodBody
    {
        public TestMethodBodyWithBooleanCheck(TestMethodBodyData data) : base(data)
        {
            AssertTemplateName = "AssertBoolean";
            AssertTemplateParameters = new { BooleanAssertMethod, TestedValue = Data.TestedValue };
        }

        private string BooleanAssertMethod => Convert.ToBoolean(Data.Expected).ToString();
    }
}