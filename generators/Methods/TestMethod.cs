using System.Collections.Generic;

namespace Generators.Methods
{
    public class TestMethod
    {
        public ISet<string> UsingNamespaces { get; set; } = new HashSet<string>();
        public string MethodName { get; set; }
        public IEnumerable<string> Body { get; set; }
        public int Index { get; set; }
    }
}