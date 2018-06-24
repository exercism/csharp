using System.Collections;

namespace Exercism.CSharp.Output
{
    public class TestMethodBodyWithEqualityCheck : TestMethodBody
    {
        public TestMethodBodyWithEqualityCheck(TestData data) : base(data)
        {
            Data.UseVariableForExpected = Data.UseVariableForExpected && !UseEmptyAssert;
            
            AssertTemplateName = UseEmptyAssert ? "AssertEqual_Empty" : "AssertEqual";
            AssertTemplateParameters = new { ExpectedParameter, TestedValue };
        }

        private bool UseEmptyAssert =>
            !(Data.Expected is string) &&
            Data.Expected is IEnumerable enumerable
            && enumerable.GetEnumerator().MoveNext() == false;
    }
}