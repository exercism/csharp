using System.Collections;

namespace Generators.Output
{
    public class TestMethodBodyWithEqualityCheck : TestMethodBody
    {
        public TestMethodBodyWithEqualityCheck(TestMethodBodyData data) : base(data)
        {
            Data.UseVariableForExpected = Data.UseVariableForExpected && !ExpectedIsEmptyEnumerable;
            InitializeTemplateParameters();
            
            AssertTemplateName = ExpectedIsEmptyEnumerable ? "AssertEqual_Empty" : "AssertEqual";
            AssertTemplateParameters = new { ExpectedParameter = Data.ExpectedParameter, TestedValue = Data.TestedValue };
        }

        private bool ExpectedIsEmptyEnumerable =>
            !(Data.Expected is string) &&
            Data.Expected is IEnumerable enumerable 
            && enumerable.GetEnumerator().MoveNext() == false;
    }
}