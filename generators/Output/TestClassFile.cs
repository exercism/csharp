using System.IO;

namespace Exercism.CSharp.Output
{
    public class TestClassFile
    {
        private readonly TestClass _testClass;

        public TestClassFile(TestClass testClass) => _testClass = testClass;

        public void Write()
        {
            var testClassFilePath = TestClassFilePath;
            var testClassContents = _testClass.Render();

            Directory.CreateDirectory(Path.GetDirectoryName(testClassFilePath));
            File.WriteAllText(testClassFilePath, testClassContents);
        }

        private string TestClassFilePath => Path.Combine("..", "exercises", _testClass.Exercise, TestClassFileName);

        private string TestClassFileName => $"{_testClass.ClassName}.cs";
    }
}