using Generators.Input;
using Serilog;

namespace Generators
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            SetupLogger();
            Generate(args);
        }

        private static void SetupLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();
        }

        private static void Generate(string[] exerciseNames)
        {
            Log.Information("Generating tests...");

            foreach (var exercise in GetExercises(exerciseNames))
                exercise.Generate();

            Log.Information("Generated tests.");
        }

        private static ExerciseCollection GetExercises(string[] exerciseNames) 
            => exerciseNames.Length == 0 ? new ExerciseCollection() : new ExerciseCollection(exerciseNames);
    }
}