using System.IO;

namespace Exercism.CSharp.Helpers
{
    internal static class FilePathHelper
    {
        public static string TestClassFilePath(string exerciseName, string exerciseTestClassName) =>
            Path.Combine("..", "exercises", exerciseName, CSharpFileName(exerciseTestClassName));

        private static string CSharpFileName(string fileName) => $"{fileName}.cs";
    }
}
