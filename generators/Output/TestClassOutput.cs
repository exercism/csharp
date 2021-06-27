using System.Collections.Generic;
using System.IO;
using System.Linq;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Output
{
    internal class TestClassOutput
    {
        private readonly TestClass _testClass;
        private readonly Options _options;

        public TestClassOutput(TestClass testClass, Options options)
        {
            _testClass = testClass;
            _options = options;
        }

        public void WriteToFile()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
            File.WriteAllText(FilePath, Render());
        }

        private string FilePath => Path.Combine(_options.PracticeExercisesDir, _testClass.Exercise, $"{_testClass.ClassName}.cs");

        private string Render() => Template.Render("TestClass", RenderParameters);

        private object RenderParameters => new
        {
            _testClass.ClassName,
            _testClass.IsDisposable,
            Methods,
            Namespaces
        };

        private IEnumerable<string> Methods =>
            _testClass.TestMethods
                .Select(testMethod => new TestMethodOutput(testMethod).Render())
                .Concat(_testClass.AdditionalMethods);

        private SortedSet<string> Namespaces =>
            _testClass.TestMethods
                .Where(x => x.ExceptionThrown != null)
                .Select(x => x.ExceptionThrown.Namespace)
                .Concat(_testClass.Namespaces)
                .Append("Xunit")
                .ToSortedSet();
    }
}