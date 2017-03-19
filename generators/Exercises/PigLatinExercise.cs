namespace Generators.Exercises
{
    public class PigLatinExercise : Exercise
    {
        public PigLatinExercise() : base("pig-latin")
        {
        }

        protected override TestMethod CreateTestMethod(TestMethodData testMethodData)
            => CreateEqualityTestMethod(testMethodData);
    }
}