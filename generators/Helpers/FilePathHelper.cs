using System.IO;

namespace Exercism.CSharp.Helpers
{
    internal static class FilePathHelper
    {
        public static string TestClassFilePath(string exerciseName, string exerciseTestClassName) => Path.Combine("..", "exercises", exerciseName, CsharpFileName(exerciseTestClassName));

        private static string CsharpFileName(string fileName) => $"{fileName}.cs";
    }
}
