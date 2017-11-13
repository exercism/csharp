using System;
using System.Diagnostics;
using CommandLine;
using Generators.Input;
using Generators.Output;
using Serilog;

namespace Generators
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            SetupLogger();

            try
            {
                Parser.Default.ParseArguments<Options>(args)
                    .WithParsed(RegenerateTestClasses);
                return 0;
            }
            catch (Exception exception) when (!Debugger.IsAttached)
            {
                Log.Error(exception, "Exception occured: {Message}", exception.Message);
                return 1;
            }
        }

        private static void SetupLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();
        }

        private static void RegenerateTestClasses(Options options)
        {
            options.Normalize();

            var canonicalDataFile = new CanonicalDataFile(options);
            canonicalDataFile.DownloadData();

            Log.Information("Re-generating test classes...");
            
            var canonicalDataParser = new CanonicalDataParser(canonicalDataFile);

            foreach (var exercise in new ExerciseCollection(canonicalDataFile))
                RegenerateTestClass(exercise, options, canonicalDataParser);

            Log.Information("Re-generated test classes.");
        }

        private static void RegenerateTestClass(Exercise exercise, Options options, CanonicalDataParser canonicalDataParser)
        {
            if (ShouldBeSkipped(exercise, options))
                return;

            switch (exercise)
            {
                case GeneratorExercise generatorExercise:
                    var canonicalData = canonicalDataParser.Parse(exercise.Name);
                    generatorExercise.Regenerate(canonicalData);

                    Log.Information("{Exercise}: tests generated", exercise.Name);
                    break;
                case UnimplementedExercise _:
                    Log.Error("{Exercise}: missing test generator", exercise.Name);
                    break;
                case CustomExercise _:
                    Log.Information("{Exercise}: has customized tests", exercise.Name);
                    break;
                case MissingDataExercise _:
                    Log.Warning("{Exercise}: missing canonical data", exercise.Name);
                    break;
            }
        }

        private static bool ShouldBeSkipped(Exercise exercise, Options options) 
            => DoesNotMatchFilteredExercise(exercise, options);

        private static bool DoesNotMatchFilteredExercise(Exercise exercise, Options options) 
            => options.Exercise != null && !string.Equals(exercise.Name, options.Exercise.ToExerciseName(), StringComparison.OrdinalIgnoreCase);
    }
}