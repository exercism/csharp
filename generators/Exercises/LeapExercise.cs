namespace Generators.Exercises
{
    public class LeapExercise : Exercise
    {
        public LeapExercise() : base("leap")
        {
        }

        protected override TestMethod CreateTestMethod(TestMethodData testMethodData)
            => CreateBooleanTestMethod(testMethodData);
    }
}