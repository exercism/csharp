using Generators.Input;
using Serilog;

namespace Generators
{
    public static class Program
    {
        public static void Main()
        {
            SetupLogger();
            GenerateAll();
        }

        private static void SetupLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();
        }

        private static void GenerateAll()
        {
            Log.Information("Generating tests...");

            foreach (var exercise in new ExerciseCollection())
                exercise.Generate();

            Log.Information("Generated tests.");
        }
    }
}