﻿namespace Generators
{
    public sealed class DeprecatedExercise : Exercise
    {
        public DeprecatedExercise(string name) => Name = name;

        public override string Name { get; }
    }
}
