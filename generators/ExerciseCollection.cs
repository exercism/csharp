using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Generators.Output;

namespace Generators
{
    public class ExerciseCollection : IEnumerable<Exercise>
    {
        private readonly string[] _exerciseNames;

        public ExerciseCollection() => _exerciseNames = null;
        public ExerciseCollection(IEnumerable<string> exerciseNames) => _exerciseNames = exerciseNames?.ToArray();
        
        public IEnumerator<Exercise> GetEnumerator() => GetDefinedGenerators().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IEnumerable<Exercise> GetDefinedGenerators() =>
            from type in Assembly.GetEntryAssembly().GetTypes()
            where IsConcreteExercise(type) && ShouldBeIncluded(type)
            select (Exercise)Activator.CreateInstance(type);

        private static bool IsConcreteExercise(Type type) => typeof(Exercise).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract;

        private bool ShouldBeIncluded(Type type) 
            => _exerciseNames == null ||
               _exerciseNames.Length == 0 ||
               _exerciseNames.Contains(type.ToExerciseName(), StringComparer.OrdinalIgnoreCase) || 
               _exerciseNames.Contains(type.Name, StringComparer.OrdinalIgnoreCase);
    }
}