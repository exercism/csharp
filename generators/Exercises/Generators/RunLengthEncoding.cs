using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RunLengthEncoding : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseFullDescriptionPath = true;
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private string RenderAssert(TestMethod method) 
            => method.Data.Property == "consistency"
                ? RenderConsistencyToAssert(method)
                : method.Assert;

        private string RenderConsistencyToAssert(TestMethod method)
        {
            var expected = Render.Object(method.Data.Expected);
            var actual = $"{method.Data.TestedClass}.Decode({method.Data.TestedClass}.Encode({expected}))";
            return Render.AssertEqual(expected, actual);
        }
    }
}