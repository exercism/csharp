using System;

namespace Exercism.CSharp.Output
{
    public class TestMethodWithBooleanAssertion : TestMethod
    {
        public TestMethodWithBooleanAssertion(TestData data) : base(data)
        {
        }
        
        protected override string RenderAssert() => Renderer.AssertBoolean(Convert.ToBoolean(Data.Expected), TestedValue);
    }
}