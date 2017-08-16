using System.Collections;
using Generators.Input;

namespace Generators.Output
{
    public class TestMethodBodyWithEqualityCheck : TestMethodBody
    {
        public TestMethodBodyWithEqualityCheck(CanonicalDataCase canonicalDataCase, CanonicalData canonicalData) : base(canonicalDataCase, canonicalData)
        {
            AssertTemplateName = ExpectedIsEmptyEnumerable ? "AssertEqual_Empty" : "AssertEqual";
            AssertTemplateParameters = new { Data.ExpectedParameter, Data.TestedValue };
        }

        public override bool UseVariableForExpected => base.UseVariableForExpected && !ExpectedIsEmptyEnumerable;

        private bool ExpectedIsEmptyEnumerable =>
            !(CanonicalDataCase.Expected is string) &&
            CanonicalDataCase.Expected is IEnumerable enumerable 
            && enumerable.GetEnumerator().MoveNext() == false;
    }
}