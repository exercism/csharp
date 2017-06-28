using Generators.Input;
using Generators.Output;

namespace Generators
{
    public abstract class Exercise
    {
        protected Exercise()
        {
            Name = GetType().ToExerciseName();
            CanonicalData = CanonicalDataParser.Parse(Name);
        }

        public string Name { get; }
        public CanonicalData CanonicalData { get; }

        public void Generate() => TestClassFile.Write(this, Render());

        protected virtual string Render() => TestClassRenderer.Render(CreateTestClass());

        protected virtual TestClass CreateTestClass() => TestClassGenerator.Create(this);
    }
}