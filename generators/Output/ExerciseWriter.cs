using System.IO;

namespace Generators.Output
{
    public class ExerciseWriter
    {
        public static void WriteToFile(GeneratorExercise generatorExercise)
        {
            var testClassFilePath = TestClassFilePath(generatorExercise);
            var testClassContents = generatorExercise.Render();

            Directory.CreateDirectory(Path.GetDirectoryName(testClassFilePath));
            File.WriteAllText(testClassFilePath, testClassContents);
        }

        private static string TestClassFilePath(GeneratorExercise generatorExercise) => Path.Combine("..", "exercises", generatorExercise.Name, TestClassFileName(generatorExercise));

        private static string TestClassFileName(GeneratorExercise generatorExercise) => $"{generatorExercise.Name.ToTestClassName()}.cs";
    }
}