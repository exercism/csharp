using System;
using System.Collections.Generic;

namespace Exercism.CSharp.Output
{
    public class TestMethodWithBooleanAssertion : TestMethod
    {
        public TestMethodWithBooleanAssertion(TestData data) : base(data)
        {
        }
        
        protected override IEnumerable<string> RenderAssert() => Assertion.Boolean(TestedValue, Convert.ToBoolean(Data.Expected));
    }
}