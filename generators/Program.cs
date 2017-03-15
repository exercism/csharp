using Generators.Exercises;
using System.IO;
using Humanizer;
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

            foreach (var exercise in new ExerciseCollection())
                TestFileGenerator.Generate(exercise);

            Log.Information("Finished generating tests for all supported exercises.");
        }
    }

    public static class TestFileGenerator
    {   
        public static void Generate(Exercise exercise)
        {
            var testClassContents = GenerateTestClassContents(exercise);
            var testClassFilePath = TestFilePath(exercise);

            SaveTestClassContentsToFile(testClassFilePath, testClassContents);
            Log.Information("Generated tests for {Exercise} exercise in {TestFile}.", exercise.Name, testClassFilePath);
        }

        private static string GenerateTestClassContents(Exercise exercise)
        {
            var canonicalData = CanonicalDataParser.Parse(exercise.Name);
            var testClass = exercise.CreateTestClass(canonicalData);
            return TestClassRenderer.Render(testClass);
        }

        private static void SaveTestClassContentsToFile(string testClassFilePath, string testClassContents) => 
            File.WriteAllText(testClassFilePath, testClassContents);

        private static string TestFilePath(Exercise exercise) => Path.Combine("..", "exercises", exercise.Name, TestFileName(exercise));

        private static string TestFileName(Exercise exercise) => $"{exercise.Name.Transform(To.TestClassName)}Test.cs";
    }
}