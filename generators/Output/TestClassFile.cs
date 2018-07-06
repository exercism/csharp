using System.IO;

namespace Exercism.CSharp.Output
{
    public static class TestClassFile
    {
        public static void Write(TestClass testClass)
        {
            var testClassFilePath = TestClassFilePath(testClass);
            var testClassContents = testClass.Render();

            Directory.CreateDirectory(Path.GetDirectoryName(testClassFilePath));
            File.WriteAllText(testClassFilePath, testClassContents);
        }

        private static string TestClassFilePath(TestClass testClass) => Path.Combine("..", "exercises", testClass.Exercise, TestClassFileName(testClass));

        private static string TestClassFileName(TestClass testClass) => $"{testClass.ClassName}.cs";
    }
}