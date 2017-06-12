using Generators.Methods;

namespace Generators.Exercises
{
    public abstract class BooleanExercise : Exercise
    {
        protected override TestMethod CreateTestMethod(TestMethodData testMethodData)
            => CreateBooleanTestMethod(testMethodData);
    }
}