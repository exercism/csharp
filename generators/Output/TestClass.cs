using System.Collections.Generic;

namespace Exercism.CSharp.Output
{
    internal class TestClass
    {
        public TestClass(string exercise, string version, string className, IReadOnlyCollection<TestMethod> testMethods)
            => (Exercise, Version, ClassName, TestMethods) = (exercise, version, className, testMethods);
        
        public string Exercise { get; }
        public string ClassName { get; }
        public string Version { get; }
        public IReadOnlyCollection<TestMethod> TestMethods { get; }
        public ICollection<string> AdditionalMethods { get; } = new List<string>();
        public ISet<string> Namespaces { get; } = new SortedSet<string>();
        public bool IsDisposable { get; set; }
    }
}