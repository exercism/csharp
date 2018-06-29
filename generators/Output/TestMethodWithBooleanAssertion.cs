using System;

namespace Exercism.CSharp.Output
{
    public class TestMethodWithBooleanAssertion : TestMethod
    {
        public TestMethodWithBooleanAssertion(TestData data) : base(data)
        {
        }
        
        protected override string RenderAssert() => Assertion.Boolean(Convert.ToBoolean(Data.Expected), TestedValue);
    }
}