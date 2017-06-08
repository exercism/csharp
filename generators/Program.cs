using Generators.Exercises;
using System.IO;
using Generators.Classes;
using Generators.Data;
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

            TestFileGenerator.Generate(new FoodChainExercise());

            foreach (var exercise in new ExerciseCollection())
                TestFileGenerator.Generate(exercise);

            Log.Information("Finished generating tests for all supported exercises.");
        }
    }

    public static class TestFileGenerator
    {   
        public static void Generate(Exercise exercise)
        {
            var testClass = CreateTestClass(exercise);
            var testClassContents = TestClassRenderer.Render(testClass);
            var testClassFilePath = TestFilePath(exercise, testClass);

            SaveTestClassContentsToFile(testClassFilePath, testClassContents);
            Log.Information("Generated tests for {Exercise} exercise in {TestFile}.", exercise.Name, testClassFilePath);
        }

        private static TestClass CreateTestClass(Exercise exercise)
        {
            var canonicalData = CanonicalDataParser.Parse(exercise.Name);
            return exercise.CreateTestClass(canonicalData);
        }

        private static void SaveTestClassContentsToFile(string testClassFilePath, string testClassContents)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(testClassFilePath));
            File.WriteAllText(testClassFilePath, testClassContents);
        }
            

        private static string TestFilePath(Exercise exercise, TestClass testClass) => Path.Combine("..", "exercises", exercise.Name, TestFileName(testClass));

        private static string TestFileName(TestClass testClass) => $"{testClass.ClassName}.cs";
    }
}