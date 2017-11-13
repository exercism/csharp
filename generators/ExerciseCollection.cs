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
        private readonly string _filteredExercise;
        
        public ExerciseCollection(string filteredExercise) => _filteredExercise = filteredExercise;

        public IEnumerator<Exercise> GetEnumerator() => GetDefinedGenerators().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IEnumerable<Exercise> GetDefinedGenerators() =>
            from type in Assembly.GetEntryAssembly().GetTypes()
            where IsConcreteExercise(type) && ShouldBeIncluded(type)
            select (Exercise)Activator.CreateInstance(type);

        private static bool IsConcreteExercise(Type type) => typeof(Exercise).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract;

        private bool ShouldBeIncluded(Type type) 
            => _filteredExercise == null ||
               string.Equals(_filteredExercise, type.ToExerciseName(), StringComparison.OrdinalIgnoreCase) ||
               string.Equals(_filteredExercise, type.Name, StringComparison.OrdinalIgnoreCase);
    }
}