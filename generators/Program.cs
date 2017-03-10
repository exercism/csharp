using System;

namespace Generators
{
    class Program
    {
        static void Main()
        {
            foreach (var generator in new GeneratorCollection())
                generator.Generate();
        }
    }

    public abstract class Generator
    {
        private static readonly CanonicalDataParser CanonicalDataParser = new CanonicalDataParser();

        public Generator(string exercise)
        {
            Exercise = exercise;
        }

        public string Exercise { get; }

        public void Generate()
        {
            Generate(CanonicalDataParser.Parse(Exercise));
        }

        protected abstract void Generate(CanonicalData canonicalData);
    }

    public class LeapExerciseGenerator : Generator
    {
        public LeapExerciseGenerator() : base("leap")
        {
        }

        protected override void Generate(CanonicalData canonicalData)
        {
            throw new NotImplementedException();
        }
    }
}