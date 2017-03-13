namespace Generators.Exercises
{
    public abstract class Exercise
    {
        protected Exercise(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract TestClass CreateTestClass(CanonicalData canonicalData);
    }
}