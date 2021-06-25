using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Exercism.CSharp.Exercises
{
    public class ExerciseGeneratorCollection : IEnumerable<ExerciseGenerator>
    {
        private readonly ExerciseGenerator[] _exerciseGenerators;

        public ExerciseGeneratorCollection(Options options) => _exerciseGenerators = GetExerciseTypesByName(options);

        private static ExerciseGenerator[] GetExerciseTypesByName(Options options) =>
            (from type in Assembly.GetEntryAssembly()!.GetTypes()
             where typeof(ExerciseGenerator).IsAssignableFrom(type) && !type.IsAbstract
             where options.Exercise == null || string.Equals(type.Name, options.Exercise, StringComparison.OrdinalIgnoreCase)
             select (ExerciseGenerator)Activator.CreateInstance(type))
            .ToArray();

        public IEnumerator<ExerciseGenerator> GetEnumerator() => _exerciseGenerators.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
