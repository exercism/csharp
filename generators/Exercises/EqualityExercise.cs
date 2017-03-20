using Generators.Methods;

namespace Generators.Exercises
{
    public abstract class EqualityExercise : Exercise
    {
        protected EqualityExercise(string name) : base(name)
        {
        }

        protected override TestMethod CreateTestMethod(TestMethodData testMethodData)
            => CreateEqualityTestMethod(testMethodData);
    }
}