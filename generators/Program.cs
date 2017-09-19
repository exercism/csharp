using System;
using System.Diagnostics;
using System.IO;
using CommandLine;
using Generators.Input;
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
            Log.Information("Re-generating test classes...");
            
            var canonicalDataParser = CreateCanonicalDataParser(options);

            foreach (var exercise in new ExerciseCollection(options.Exercises))
            {
                var canonicalData = canonicalDataParser.Parse(exercise);
                exercise.Regenerate(canonicalData);
            }

            Log.Information("Re-generated test classes.");
        }

        private static CanonicalDataParser CreateCanonicalDataParser(Options options)
        {
            var canonicalDataOptions = new CanonicalDataOptions
            {
                CanonicalDataDirectory = options.CanonicalDataDirectory ?? DefaultCanonicalDataDirectory,
                CacheCanonicalData = options.CacheCanonicalData
            };
            return new CanonicalDataParser(canonicalDataOptions);
        }

        private static string DefaultCanonicalDataDirectory 
            => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "exercism", "problem-specifications");
    }
}