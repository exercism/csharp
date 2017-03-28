using Generators.Methods;

namespace Generators.Exercises
{
    public abstract class EqualityExercise : Exercise
    {
        protected EqualityExercise(string name) : base(name)
        {
        }

        protected override TestMethod CreateTestMethod(TestMethodData testMethodData)
        {
            if (testMethodData.Options.ThrowExceptionWhenExpectedValueEquals(testMethodData.CanonicalDataCase.Expected))
                return CreateExceptionTestMethod(testMethodData);

            return CreateEqualityTestMethod(testMethodData);
        }
    }
}