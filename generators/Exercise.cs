﻿using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators
{
    public abstract class Exercise
    {
        protected Exercise()
        {
            Name = GetType().Name.Kebaberize();
            CanonicalData = CanonicalDataParser.Parse(Name);
            Configuration = new ExerciseConfiguration();
        }

        public string Name { get; }
        public CanonicalData CanonicalData { get; }
        public ExerciseConfiguration Configuration { get; }

        public void Generate() => TestClassFile.Write(this, Render());

        protected virtual string Render() => TestClassRenderer.Render(CreateTestClass());

        protected virtual TestClass CreateTestClass() => TestClassGenerator.Create(this);
    }
}