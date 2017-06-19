using Generators.Output;

namespace Generators.Exercises
{
    public abstract class EqualityExercise : Exercise
    {
        protected override TestMethod CreateTestMethod(TestMethodData testMethodData)
        {
            if (testMethodData.Options.ThrowExceptionWhenExpectedValueEquals(testMethodData.CanonicalDataCase.Expected))
                return ExceptionTestMethod.Create(testMethodData);

            return EqualityTestMethod.Create(testMethodData);
        }
    }
}