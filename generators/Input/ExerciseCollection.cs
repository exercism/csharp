using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Generators.Exercises;

namespace Generators.Input
{
    public class ExerciseCollection : IEnumerable<Exercise>
    {
        private readonly IEnumerable<Exercise> _generators = GetDefinedGenerators();

        public IEnumerator<Exercise> GetEnumerator() => _generators.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static IEnumerable<Exercise> GetDefinedGenerators() =>
            from type in Assembly.GetEntryAssembly().GetTypes()
            where typeof(Exercise).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract
            select (Exercise)Activator.CreateInstance(type);
    }
}