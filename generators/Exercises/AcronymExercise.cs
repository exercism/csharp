namespace Generators.Exercises
{
    public class AcronymExercise : Exercise
    {
        public AcronymExercise() : base("acronym")
        {
        }

        protected override TestMethod CreateTestMethod(TestMethodData testMethodData)
        {
            testMethodData.InputProperty = "phrase";
            return new EqualityTestMethod(testMethodData);
        }
    }
}