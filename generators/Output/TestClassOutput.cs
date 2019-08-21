using System.Collections.Generic;
using System.IO;
using System.Linq;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Output
{
    public class TestClassOutput
    {
        private readonly TestClass _testClass;
        
        public TestClassOutput(TestClass testClass)
            => _testClass = testClass;
        
        public void WriteToFile()
        {
            var filePath = FilePathHelper.TestClassFilePath(_testClass.Exercise, _testClass.ClassName);
            var renderedContents = Render();

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, renderedContents);
        }
        
        private string Render() => Template.Render("TestClass", RenderParameters);

        private object RenderParameters => new
        {
            _testClass.ClassName,
            _testClass.Version,
            _testClass.IsDisposable,
            Methods,
            Namespaces
        };

        private IEnumerable<string> Methods 
            => _testClass.TestMethods
                .Select(testMethod => new TestMethodOutput(testMethod).Render())
                .Concat(_testClass.AdditionalMethods);

        private SortedSet<string> Namespaces
            => _testClass.TestMethods
                    .Where(x => x.ExceptionThrown != null)
                    .Select(x => x.ExceptionThrown.Namespace)
                    .Concat(_testClass.Namespaces)
                    .Append("Xunit")
                    .ToSortedSet();
    }
}