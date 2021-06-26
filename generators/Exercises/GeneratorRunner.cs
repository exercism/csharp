﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Exercism.CSharp.Input;

using Serilog;

namespace Exercism.CSharp.Exercises
{
    internal class GeneratorRunner
    {
        private readonly CanonicalDataParser _canonicalDataParser;
        private readonly Dictionary<string, Type> _exerciseGeneratorTypes;
        
        public GeneratorRunner(Options options)
        {
            _canonicalDataParser = CanonicalDataParser.Create(options);
            _exerciseGeneratorTypes = FindExerciseGeneratorTypes();
        }

        public void RegenerateAllExercises()
        {
            foreach (var exerciseGeneratorType in _exerciseGeneratorTypes.Values)
                RegenerateExercise(exerciseGeneratorType);
        }

        public void RegenerateSingleExercise(string exercise)
        {
            if (_exerciseGeneratorTypes.TryGetValue(exercise, out var exerciseGeneratorType))
                RegenerateExercise(exerciseGeneratorType);
            else
                Log.Error("Could not find generator for {Exercise} exercise", exercise);
        }

        private void RegenerateExercise(Type exerciseGeneratorType)
        {
            var exerciseGenerator = (ExerciseGenerator) Activator.CreateInstance(exerciseGeneratorType);
            exerciseGenerator!.Regenerate(_canonicalDataParser.Parse(exerciseGenerator.Name));
            Log.Information("{Exercise}: updated", exerciseGenerator.Name);
        }

        private static Dictionary<string, Type> FindExerciseGeneratorTypes() =>
            Assembly.GetEntryAssembly()!.GetTypes()
                .Where(type => typeof(ExerciseGenerator).IsAssignableFrom(type) && !type.IsAbstract)
                .ToDictionary(type => type.Name, type => type, StringComparer.OrdinalIgnoreCase);
    }
}
