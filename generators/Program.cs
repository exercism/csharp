using System;
using CommandLine;
using Exercism.CSharp.Exercises;
using Exercism.CSharp.Input;
using Serilog;

namespace Exercism.CSharp
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            SetupLogger();

            try
            {
                Parser.Default.ParseArguments<Options>(args)
                    .WithParsed(options => RegenerateTestClasses(options, args));
                return 0;
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Exception occured: {Exception}", exception.Message);
                return 1;
            }
        }

        private static void SetupLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();
        }

        private static void RegenerateTestClasses(Options options, string[] args)
        {
            options.Setup(args);

            var canonicalDataFile = new CanonicalDataFile(options);
            canonicalDataFile.DownloadData();

            if(options.ShouldGenerate)
                Log.Information("Re-generating test classes...");
            
            var canonicalDataParser = new CanonicalDataParser(canonicalDataFile);

            foreach (var exercise in new ExerciseGeneratorCollection(options))
                RegenerateTestClass(exercise, canonicalDataParser);

            if (options.ShouldGenerate)
                Log.Information("Re-generated test classes.");
        }

        private static void RegenerateTestClass(ExerciseGenerator exercise, CanonicalDataParser canonicalDataParser)
        {
            var canonicalData = canonicalDataParser.Parse(exercise.Name);
            exercise.Regenerate(canonicalData);

            Log.Information("{Exercise}: tests generated", exercise.Name);
        }
    }
}