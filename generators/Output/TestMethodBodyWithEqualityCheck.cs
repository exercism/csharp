using System.Collections;
using Generators.Input;

namespace Generators.Output
{
    public class TestMethodBodyWithEqualityCheck : TestMethodBody
    {
        public TestMethodBodyWithEqualityCheck(TestMethodBodyData data) : base(data)
        {
            Data.UseVariableForExpected = Data.UseVariableForExpected && !ExpectedIsEmptyEnumerable;
            InitializeTemplateParameters();
            
            AssertTemplateName = ExpectedIsEmptyEnumerable ? "AssertEqual_Empty" : "AssertEqual";
            AssertTemplateParameters = new { Data.ExpectedParameter, Data.TestedValue };
        }

        private bool ExpectedIsEmptyEnumerable =>
            !(Data.CanonicalDataCase.Expected is string) &&
            Data.CanonicalDataCase.Expected is IEnumerable enumerable 
            && enumerable.GetEnumerator().MoveNext() == false;
    }
}