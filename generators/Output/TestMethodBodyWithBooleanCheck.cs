using System;

namespace Exercism.CSharp.Output
{
    public class TestMethodBodyWithBooleanCheck : TestMethodBody
    {
        public TestMethodBodyWithBooleanCheck(TestData data) : base(data)
        {
            AssertTemplateName = "AssertBoolean";
            AssertTemplateParameters = new { BooleanAssertMethod, TestedValue };
        }

        private string BooleanAssertMethod => Convert.ToBoolean(Data.Expected).ToString();
    }
}