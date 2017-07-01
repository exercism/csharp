using CommandLine;
using Serilog;

namespace Generators
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            SetupLogger();

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Generate);
        }

        private static void SetupLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();
        }

        private static void Generate(Options options)
        {
            Log.Information("Generating tests...");

            foreach (var exercise in new ExerciseCollection(options.Exercises))
                exercise.Generate();

            Log.Information("Generated tests.");
        }
    }
}