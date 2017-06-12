using Generators.Data;
using Generators.Exercises;
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
            Log.Information("Start generating tests...");

            TestFileGenerator.Generate(new BeerSong());

            //foreach (var exercise in new ExerciseCollection())
            //    TestFileGenerator.Generate(exercise);

            Log.Information("Finished generating tests for all supported exercises.");
        }
    }
}