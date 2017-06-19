using System.IO;
using Generators.Exercises;
using Serilog;

namespace Generators.Output
{
    public static class TestFileGenerator
    {   
        public static void Generate(Exercise exercise)
        {
            var testClass = exercise.CreateTestClass();
            var testClassContents = TestClassRenderer.Render(testClass);
            var testClassFilePath = TestFilePath(exercise, testClass);

            SaveTestClassContentsToFile(testClassFilePath, testClassContents);
            Log.Information("Generated tests for {Exercise} exercise in {TestFile}.", exercise.Name, testClassFilePath);
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