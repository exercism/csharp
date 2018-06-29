using System;

namespace Exercism.CSharp.Output
{
    public class TestMethodWithBooleanAssertion : TestMethod
    {
        public TestMethodWithBooleanAssertion(TestData data) : base(data)
        {
        }
        
        protected override string RenderAssert() => Assertion.Boolean(TestedValue, Convert.ToBoolean(Data.Expected));
    }
}