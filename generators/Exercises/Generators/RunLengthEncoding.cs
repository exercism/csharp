using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RunLengthEncoding : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestMethodName = testMethod.TestMethodNameWithPath;

            if (testMethod.Property == "consistency")
                testMethod.Assert = RenderConsistencyToAssert(testMethod);
        }

        private string RenderConsistencyToAssert(TestMethod testMethod)
        {
            var expected = Render.Object(testMethod.Expected);
            var actual = $"{testMethod.TestedClass}.Decode({testMethod.TestedClass}.Encode({expected}))";
            return Render.AssertEqual(expected, actual);
        }
    }
}