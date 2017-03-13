using Generators.Exercises;
using System.IO;

namespace Generators
{
    public static class Program
    {
        public static void Main()
        {
            foreach (var exercise in new ExerciseCollection())
                TestFileGenerator.Generate(exercise);
        }
    }

    public static class TestFileGenerator
    {   
        public static void Generate(Exercise exercise)
        {
            var testClassContents = GenerateTestClassContents(exercise);
            SaveTestClassContentsToFile(TestFilePath(exercise), testClassContents);
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

        private static string TestFileName(Exercise exercise) => $"{exercise.Name}Test.cs";
    }
}