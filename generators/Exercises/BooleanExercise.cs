using Generators.Methods;

namespace Generators.Exercises
{
    public abstract class BooleanExercise : Exercise
    {
        protected BooleanExercise(string name) : base(name)
        {
        }

        protected override TestMethod CreateTestMethod(TestMethodData testMethodData)
            => CreateBooleanTestMethod(testMethodData);
    }
}