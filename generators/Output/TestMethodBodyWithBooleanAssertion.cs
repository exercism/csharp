using System;

namespace Exercism.CSharp.Output
{
    public class TestMethodBodyWithBooleanAssertion : TestMethodBody
    {
        public TestMethodBodyWithBooleanAssertion(TestData data) : base(data)
        {
            AssertTemplateName = "AssertBoolean";
            AssertTemplateParameters = new { BooleanAssertMethod, TestedValue };
        }

        private string BooleanAssertMethod => Convert.ToBoolean(Data.Expected).ToString();
    }
}