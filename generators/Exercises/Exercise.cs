namespace Generators.Exercises
{
    public abstract class Exercise
    {
        public Exercise(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract TestClass CreateTestClass(CanonicalData canonicalData);
    }
}