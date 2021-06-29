using System.Collections.Generic;

namespace Exercism.CSharp.Output
{
    internal record TestClass(string Exercise, string ClassName, IReadOnlyCollection<TestMethod> TestMethods)
    {
        public ICollection<string> AdditionalMethods { get; } = new List<string>();
        public ISet<string> Namespaces { get; } = new SortedSet<string>();
        public bool IsDisposable { get; set; }
    }
}