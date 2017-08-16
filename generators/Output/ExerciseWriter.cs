using System.IO;
using Serilog;

namespace Generators.Output
{
    public class ExerciseWriter
    {
        public virtual void WriteToFile(Exercise exercise)
        {
            var testClassFilePath = TestClassFilePath(exercise);
            var testClassContents = exercise.Render();

            Directory.CreateDirectory(Path.GetDirectoryName(testClassFilePath));
            File.WriteAllText(testClassFilePath, testClassContents);

            Log.Information("Generated tests for {Exercise} exercise in {TestFile}", exercise.Name, testClassFilePath);
        }

        private static string TestClassFilePath(Exercise exercise) => Path.Combine("..", "exercises", exercise.Name, TestClassFileName(exercise));

        private static string TestClassFileName(Exercise exercise) => $"{exercise.Name.ToTestClassName()}.cs";
    }
}