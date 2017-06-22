using System.IO;
using Serilog;

namespace Generators.Output
{
    public static class TestClassFile
    {
        public static void Write(Exercise exercise, string contents)
        {
            var testClassFilePath = TestClassFilePath(exercise);

            Directory.CreateDirectory(Path.GetDirectoryName(testClassFilePath));
            File.WriteAllText(testClassFilePath, contents);

            Log.Information("Generated tests for {Exercise} exercise in {TestFile}.", exercise.Name, testClassFilePath);
        }

        private static string TestClassFilePath(Exercise exercise) => Path.Combine("..", "exercises", exercise.Name, TestClassFileName(exercise));

        private static string TestClassFileName(Exercise exercise) => $"{exercise.Name.ToTestClassName()}.cs";
    }
}