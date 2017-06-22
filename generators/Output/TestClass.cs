using System.Collections.Generic;

namespace Generators.Output
{
    public class TestClass
    {
        public string ClassName { get; set; }
        public string CanonicalDataVersion { get; set; }
        public TestMethod[] TestMethods { get; set; }
        public ISet<string> UsingNamespaces { get; } = new HashSet<string> { "Xunit" };
    }    
}