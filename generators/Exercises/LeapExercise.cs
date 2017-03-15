namespace Generators.Exercises
{
    public class LeapExercise : Exercise
    {
        public LeapExercise() : base("leap")
        {
        }

        protected override TestMethod CreateTestMethod(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
            =>  new BooleanTestMethod(canonicalData, canonicalDataCase, index);
    }
}