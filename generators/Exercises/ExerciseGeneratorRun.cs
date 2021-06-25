using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Exercism.CSharp.Input;

using Serilog;

namespace Exercism.CSharp.Exercises
{
    public class ExerciseGeneratorRun : IEnumerable<ExerciseGenerator>
    {
        public static void RegenerateTestClasses(Options options)
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

        public static void RegenerateTestClass(Options options, string exercise)
        {
            // var canonicalData = canonicalDataParser.Parse(exercise.Name);
            // exercise.Regenerate(canonicalData);
            //
            // Log.Information("{Exercise}: tests generated", exercise.Name);
        }
        
        
        
        private readonly ExerciseGenerator[] _exerciseGenerators;

        public ExerciseGeneratorRun(Options options) => _exerciseGenerators = GetExerciseTypesByName(options);

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
