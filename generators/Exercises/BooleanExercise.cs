using Generators.Methods;

namespace Generators.Exercises
{
    public abstract class BooleanExercise : Exercise
    {
        protected override TestMethod CreateTestMethod(TestMethodData testMethodData)
        {
            if (testMethodData.Options.ThrowExceptionWhenExpectedValueEquals(testMethodData.CanonicalDataCase.Expected))
                return ExceptionTestMethodGenerator.Create(testMethodData);

            return BooleanTestMethodGenerator.Create(testMethodData);
        }
    }
}