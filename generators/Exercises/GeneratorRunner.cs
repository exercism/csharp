using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Exercism.CSharp.Input;

using Serilog;

namespace Exercism.CSharp.Exercises
{
    public static class GeneratorRunner
    {
        private static readonly Dictionary<string, Type> GeneratorTypes =
            Assembly.GetEntryAssembly()!.GetTypes()
                .Where(type => typeof(ExerciseGenerator).IsAssignableFrom(type) && !type.IsAbstract)
                .ToDictionary(type => type.Name, type => type);
    
        public static void RegenerateAll(Options options)
        {
            // TODO: spl
            
            var canonicalDataFile = new CanonicalDataFile(options);
            canonicalDataFile.DownloadData();

            Log.Information("Re-generating test class(es)...");
            
            var canonicalDataParser = new CanonicalDataParser(canonicalDataFile);

            // foreach (var exercise in new ExerciseGeneratorCollection(options))
            //     RegenerateTestClass(exercise, canonicalDataParser);

            Log.Information("Re-generated test class(es).");
        }

        public static void RegenerateExercise(Options options, string exercise)
        {
            // var canonicalData = canonicalDataParser.Parse(exercise.Name);
            // exercise.Regenerate(canonicalData);
            //
            // Log.Information("{Exercise}: tests generated", exercise.Name);
        }
        
        //
        //
        // private readonly ExerciseGenerator[] _exerciseGenerators;
        //
        // public GeneratorRunner(Options options) => _exerciseGenerators = GetExerciseTypesByName(options);
        //
        // private static ExerciseGenerator[] GetExerciseTypesByName(Options options) =>
        //     (
        //      where options.Exercise == null || string.Equals(type.Name, options.Exercise, StringComparison.OrdinalIgnoreCase)
        //      select (ExerciseGenerator)Activator.CreateInstance(type))
        //     .ToArray();

    }
}
