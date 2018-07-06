using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RunLengthEncoding : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestMethodName = testMethod.TestMethodNameWithPath;

            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAssert(TestMethod testMethod) 
            => testMethod.Property == "consistency"
                ? RenderConsistencyToAssert(testMethod)
                : testMethod.Assert;

        private string RenderConsistencyToAssert(TestMethod testMethod)
        {
            var expected = Render.Object(testMethod.Expected);
            var actual = $"{testMethod.TestedClass}.Decode({testMethod.TestedClass}.Encode({expected}))";
            return Render.AssertEqual(expected, actual);
        }
    }
}